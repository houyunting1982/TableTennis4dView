import { useState, useEffect, useCallback } from 'react';
import Displayer from '../components/player/Displayer';
import Sidebar from '../components/player/Sidebar';
import Header from '../components/player/Header';
import { CircularProgress, InputAdornment, Stack, TextField } from '@mui/material';
import FilterAltIcon from '@mui/icons-material/FilterAlt';
import { styled } from '@mui/material/styles';
import Grid from '@mui/material/Unstable_Grid2';
import ControlPanel from '../components/player/ControlPanel';

import { preloadImage } from '../services/utils';
import { useParams } from 'react-router-dom';
import { useAuth } from '../hooks/useAuth';
import { getPlayerById } from '../services/apis/playersApi';
import { getTechniquesbyPlayerId } from '../services/apis/techniquesApi';

const Container = styled(Stack)({
    textAlign: 'center',
    maxWidth: '1600px',
    minWidth: '1200px',
    margin: '100px auto',
    padding: '0 50px'
});

const SearchBarField = styled(TextField)({
    input: { color: '#fff' },
    backgroundColor: "#444",
    borderRadius: '5px'
});

const initStatus = {
    currentCamera: 0,
    currentIndex: 0
}

const initBoundary = {
    maxCamera: 0,
    maxIndex: 0
}

const initPlayParams = {
    indexSpeedMultiplier: 0,
    playDirection: 0, // -1 : prev, 0 : Current, 1 : next
    cameraMovingDirection: 0 // -1 : prev, 0 : Current, 1 : next
}
const defaultSpeed = 15;

const PlayPage = () => {
    const { userId, token } = useAuth();
    const { playerId } = useParams();
    const [playStatus, setPlayStatus] = useState(initStatus);
    const [boundary, setBoundary] = useState(initBoundary);

    const [indexIntervalId, setindexIntervalId] = useState(0);
    const [cameraIntervalId, setcameraIntervalId] = useState(0);
    const [playerName, setPlayerName] = useState(null);
    const [joyStickParams, setjoyStickParams] = useState(initPlayParams);
    const [enableJoyStickMode, setenableJoyStickMode] = useState(false);
    const [techniques, setTechniques] = useState([]);

    const [selectedTechnique, setSelectedTechnique] = useState(null);
    const [filterCondition, setFilterCondition] = useState(null);
    const [playSpeed, setPlaySpeed] = useState(defaultSpeed);
    const preLoadImages = async (images) => {
        const imagesPromiseList = [];
        for (let cIdx = 0; cIdx < images.length; cIdx++) {
            for (let fIdx = 0; fIdx < images[cIdx].length; fIdx++) {
                imagesPromiseList.push(preloadImage(images[cIdx][fIdx]));
            }
        }
        try {
            await Promise.all(imagesPromiseList);
            console.log("All pictures are loaded");
        }
        catch (err) {
            console.log("Cancelled before finishing loading");
        }
    }

    const setCurrentTechnique = useCallback((techniqueId) => {
        if (indexIntervalId) {
            clearInterval(indexIntervalId);
            setindexIntervalId(0);
        }
        setSelectedTechnique(techniques.find(t => t.id === parseInt(techniqueId)));
        setPlayStatus(initStatus);
        setPlaySpeed(20);
    }, [indexIntervalId, techniques, indexIntervalId])

    useEffect(() => {
        if (!selectedTechnique) {
            return;
        }
        const maxCamera = selectedTechnique.cameraViews.length;
        const maxIndex = selectedTechnique.cameraViews[0].parsedImages.length;
        setBoundary({ maxCamera, maxIndex });
        const cameraImages = selectedTechnique.cameraViews.map(cv => cv.parsedImages);
        preLoadImages(cameraImages);
    }, [selectedTechnique])

    useEffect(() => {
        const init = async () => {
            const playerData = await getPlayerById(playerId, token);
            setPlayerName(`${playerData.data.firstName} ${playerData.data.lastName}`);
            const techniquesData = await getTechniquesbyPlayerId(playerId, token);
            setTechniques(techniquesData.data)
            setSelectedTechnique(techniquesData.data[0]);
        }
        init();
    }, [setPlayerName, setTechniques])

    const resetjoyStickParams = () => setjoyStickParams(initPlayParams);

    const goToPrevIndex = useCallback((step = 1) => {
        if (indexIntervalId) {
            clearInterval(indexIntervalId);
            setindexIntervalId(0);
        }
        setPlayStatus(prev => ({
            ...prev,
            currentIndex: prev.currentIndex - step < 0 ? 0 : prev.currentIndex - step,
        }));
    }, [indexIntervalId]);

    const goToNextIndex = useCallback((step = 1, loopMode = false) => {
        if (indexIntervalId) {
            clearInterval(indexIntervalId);
            setindexIntervalId(0);
        }
        setPlayStatus(prev => ({
            ...prev,
            currentIndex: prev.currentIndex + step >= boundary.maxIndex ?
                loopMode ?
                    0 : boundary.maxIndex - 1
                : prev.currentIndex + step,
        }));
    }, [boundary.maxIndex, indexIntervalId]);

    const goToPrevCamera = useCallback(() => {
        setPlayStatus(prev => ({
            ...prev,
            currentCamera: prev.currentCamera - 1 < 0 ? 0 : prev.currentCamera - 1,
        }))
    }, []);

    const goToNextCamera = useCallback(() => {
        setPlayStatus(prev => ({
            ...prev,
            currentCamera: prev.currentCamera + 1 >= boundary.maxCamera ? boundary.maxCamera - 1 : prev.currentCamera + 1,
        }))
    }, [boundary.maxCamera])

    const goPlay = useCallback(() => {
        if (indexIntervalId) {
            clearInterval(indexIntervalId);
            setindexIntervalId(0);
            return;
        }

        const newIntervalId = setInterval(() => goToNextIndex(1, true), playSpeed);
        setindexIntervalId(newIntervalId);
    }, [goToNextIndex, indexIntervalId, playSpeed]);

    const getCurrentImageUrl = () => {
        if (!selectedTechnique) {
            return null;
        }
        return selectedTechnique.cameraViews[playStatus.currentCamera].parsedImages[playStatus.currentIndex];
    }

    const canGoPrevIndex = () => {
        return playStatus.currentIndex === 0;
    }

    const canGoNextIndex = () => {
        return playStatus.currentIndex === boundary.maxIndex - 1;
    }

    const canGoPrevCamera = () => {
        return playStatus.currentCamera === 0;
    }

    const canGoNextCamera = () => {
        return playStatus.currentCamera === boundary.maxCamera - 1;
    }

    const handleKeyPress = useCallback((e) => {
        switch (e.code) {
            case 'ArrowRight':
                goToNextCamera();
                break;
            case 'ArrowLeft':
                goToPrevCamera();
                break;
            case 'ArrowDown':
                goToPrevIndex();
                break;
            case 'ArrowUp':
                goToNextIndex();
                break;
            case 'Space':
                e.preventDefault();
                goPlay();
                break;
            case 'Digit1':
                if (indexIntervalId) {
                    clearInterval(indexIntervalId);
                    setindexIntervalId(0);
                }
                setPlaySpeed(defaultSpeed);
                break;
            case 'Digit2':
                if (indexIntervalId) {
                    clearInterval(indexIntervalId);
                    setindexIntervalId(0);
                }
                setPlaySpeed(defaultSpeed * 2);
                break;
            case 'Digit3':
                if (indexIntervalId) {
                    clearInterval(indexIntervalId);
                    setindexIntervalId(0);
                }
                setPlaySpeed(defaultSpeed * 4);
                break;
            case 'Digit4':
                if (indexIntervalId) {
                    clearInterval(indexIntervalId);
                    setindexIntervalId(0);
                }
                setPlaySpeed(defaultSpeed * 10);
                break;
            default:
                break;
        }
    }, [goToNextCamera, goToPrevCamera, goToPrevIndex, goToNextIndex, goPlay, indexIntervalId])

    useEffect(() => {
        if (!enableJoyStickMode) {
            return;
        }
        if (indexIntervalId) {
            clearInterval(indexIntervalId);
            setindexIntervalId(0);
        }
        if (cameraIntervalId) {
            clearInterval(cameraIntervalId);
            setcameraIntervalId(0);
        }
        if (joyStickParams.playDirection === 1) {
            setindexIntervalId(setInterval(() => goToNextIndex(), Math.ceil(30 / joyStickParams.indexSpeedMultiplier)));
        } else if (joyStickParams.playDirection === -1) {
            setindexIntervalId(setInterval(() => goToPrevIndex(), Math.ceil(30 / joyStickParams.indexSpeedMultiplier)));
        }
        if (joyStickParams.cameraMovingDirection === 1) {
            setcameraIntervalId(setInterval(() => goToNextCamera(), 200));
        } else if (joyStickParams.cameraMovingDirection === -1) {
            setcameraIntervalId(setInterval(() => goToPrevCamera(), 200));
        }
    }, [enableJoyStickMode, joyStickParams, goToNextCamera, goToNextIndex, goToPrevCamera, goToPrevIndex])

    useEffect(() => {
        // attach the event listener
        document.addEventListener('keydown', handleKeyPress);
        return () => {
            document.removeEventListener('keydown', handleKeyPress);
        };
    }, [handleKeyPress]);

    return (
        selectedTechnique ?
            <>
                <Container>
                    <Header title={selectedTechnique.title} playerName={playerName} />
                    <Grid container alignItems="center" spacing={2}>
                        <Grid item xs={3}>
                            <Stack spacing={3} alignItems="center">
                                <SearchBarField
                                    id="search"
                                    type="search"
                                    value={filterCondition}
                                    onChange={e => setFilterCondition(e.target.value)}
                                    sx={{width: '280px'}}
                                    InputProps={{
                                        endAdornment: (
                                            <InputAdornment position="end">
                                                <FilterAltIcon sx={{color: 'white'}}/>
                                            </InputAdornment>
                                        ),
                                    }}
                                    onFocus={(event) => {
                                        event.target.setAttribute('autocomplete', 'off');
                                        console.log(event.target.autocomplete);
                                      }}
                                />
                                <Sidebar techniques={techniques} selectedTechnique={selectedTechnique} setCurrentTechnique={setCurrentTechnique} filterCondition={filterCondition}/>
                            </Stack>
                        </Grid>
                        <Grid item xs={9}>
                            <Displayer
                                imageSrc={getCurrentImageUrl()}
                                enableJoyStickMode={enableJoyStickMode}
                                setjoyStickParams={setjoyStickParams}
                                resetjoyStickParams={resetjoyStickParams}
                            />
                        </Grid>
                        <Grid xsOffset={3} xs={9}>
                            <ControlPanel
                                goToNextIndex={goToNextIndex}
                                goToPrevIndex={goToPrevIndex}
                                goToNextCamera={goToNextCamera}
                                goToPrevCamera={goToPrevCamera}
                                goPlay={goPlay}
                                isPlaying={!!indexIntervalId}
                                canGoNextCamera={canGoNextCamera}
                                canGoPrevCamera={canGoPrevCamera}
                                canGoNextIndex={canGoNextIndex}
                                canGoPrevIndex={canGoPrevIndex}
                                playSpeed={playSpeed}
                                enableJoyStickMode={enableJoyStickMode}
                                joyStickParams={joyStickParams}
                                defaultSpeed={defaultSpeed}
                            />
                        </Grid>
                    </Grid>
                </Container>
            </>
            :
            <CircularProgress />
    )
}

export default PlayPage