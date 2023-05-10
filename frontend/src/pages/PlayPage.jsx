import { useState, useEffect, useCallback } from 'react';
import Displayer from '../components/player/Displayer';
import Sidebar from '../components/player/Sidebar';
import Header from '../components/player/Header';
import { CircularProgress, Stack, TextField } from '@mui/material';
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

const defaultSpeed = 17;

const PlayPage = () => {
    const { token } = useAuth();
    const { playerId } = useParams();
    const [playStatus, setPlayStatus] = useState(initStatus);
    const [boundary, setBoundary] = useState(initBoundary);

    const [indexIntervalId, setindexIntervalId] = useState(0);
    const [playerName, setPlayerName] = useState(null);
    const [techniques, setTechniques] = useState([]);

    const [selectedTechnique, setSelectedTechnique] = useState(null);
    const [filterCondition, setFilterCondition] = useState("");
    const [playSpeed, setPlaySpeed] = useState(defaultSpeed);
    const [isPlaying, setIsPlaying] = useState(false);
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

    const cleanPlayStatus = (indexIntervalId, needToUpdatePlaying = false) => {
        clearInterval(indexIntervalId);
        setindexIntervalId(0);
        if (needToUpdatePlaying) {
            setIsPlaying(false);
        }
    }

    const setCurrentTechnique = useCallback((techniqueId) => {
        if (indexIntervalId) {
            cleanPlayStatus(indexIntervalId, true)
        }
        const technique = techniques.find(t => t.id === parseInt(techniqueId));
        setSelectedTechnique(technique);
        const maxCamera = technique.cameraViews.length;
        const maxIndex = technique.cameraViews[0].parsedImages.length;
        setBoundary({ maxCamera, maxIndex });
        setPlayStatus(initStatus);

    }, [indexIntervalId, techniques])

    const goToPrevIndex = useCallback((step = 1) => {
        if (indexIntervalId) {
            cleanPlayStatus(indexIntervalId, true)
        }
        setPlayStatus(prev => ({
            ...prev,
            currentIndex: prev.currentIndex - step < 0 ? 0 : prev.currentIndex - step,
        }));
    }, [indexIntervalId]);

    const goToNextIndex = useCallback((step = 1, loopMode = false) => {
        if (indexIntervalId) {
            cleanPlayStatus(indexIntervalId, true)
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
            cleanPlayStatus(indexIntervalId, true);
            return;
        }
        const newIntervalId = setInterval(() => goToNextIndex(1, true), playSpeed);
        setindexIntervalId(newIntervalId);
        setIsPlaying(true);
    }, [goToNextIndex, setIsPlaying, setindexIntervalId, indexIntervalId, playSpeed]);

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
        console.log(e.code)
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
                if (indexIntervalId) {
                    cleanPlayStatus(indexIntervalId, true);
                    return;
                }
                const newIntervalId = setInterval(() => goToNextIndex(1, true), playSpeed);
                setindexIntervalId(newIntervalId);
                setIsPlaying(true);
                break;
            case 'Digit1':
            case 'Numpad1':
                if (indexIntervalId) {
                    cleanPlayStatus(indexIntervalId);
                }
                setPlaySpeed(defaultSpeed);
                break;
            case 'Digit2':
            case 'Numpad2':
                if (indexIntervalId) {
                    cleanPlayStatus(indexIntervalId);
                }
                setPlaySpeed(defaultSpeed * 2);
                break;
            case 'Digit3':
            case 'Numpad3':
                if (indexIntervalId) {
                    cleanPlayStatus(indexIntervalId);
                }
                setPlaySpeed(defaultSpeed * 4);
                break;
            case 'Digit4':
            case 'Numpad4':
                if (indexIntervalId) {
                    cleanPlayStatus(indexIntervalId);
                }
                setPlaySpeed(defaultSpeed * 10);
                break;
            default:
                break;
        }
    }, [goToNextCamera, goToPrevCamera, goToPrevIndex, goToNextIndex, indexIntervalId, playSpeed
    ])

    useEffect(() => {
        // attach the event listener
        document.addEventListener('keydown', handleKeyPress);
        return () => {
            document.removeEventListener('keydown', handleKeyPress);
        };
    }, [handleKeyPress]);

    useEffect(() => {
        const init = async () => {
            const playerData = await getPlayerById(playerId, token);
            setPlayerName(`${playerData.data.firstName} ${playerData.data.lastName}`);
            const techniquesData = await getTechniquesbyPlayerId(playerId, token);
            setTechniques(techniquesData.data)
            setSelectedTechnique(techniquesData.data[0]);
        }
        init();
    }, [setPlayerName, setTechniques, playerId, token]);

    useEffect(() => {
        if (!selectedTechnique) {
            return;
        }
        const maxCamera = selectedTechnique.cameraViews.length;
        const maxIndex = selectedTechnique.cameraViews[0].parsedImages.length;
        setBoundary({ maxCamera, maxIndex });
        const cameraImages = selectedTechnique.cameraViews.map(cv => cv.parsedImages);
        preLoadImages(cameraImages);
    }, [selectedTechnique]);

    useEffect(() => {
        if (isPlaying && !indexIntervalId) {
            const newIntervalId = setInterval(() => goToNextIndex(1, true), playSpeed);
            setindexIntervalId(newIntervalId);
        }
    }, [isPlaying, playSpeed, indexIntervalId, goToNextIndex, setindexIntervalId])

    return (
        selectedTechnique ?
            <>
                <Container>
                    <Header title={selectedTechnique.title} playerName={playerName} />
                    <Grid container alignItems="center" spacing={4} minWidth={"1400px"}>
                        <Grid item xs={3}>
                            <Stack spacing={3} alignItems="center">
                                <SearchBarField
                                    id="search"
                                    type="search"
                                    value={filterCondition}
                                    onChange={e => setFilterCondition(e.target.value)}
                                    sx={{ width: '280px' }}
                                    onFocus={(event) => { event.target.setAttribute('autocomplete', 'off') }}
                                />
                                <Sidebar techniques={techniques} selectedTechnique={selectedTechnique} setCurrentTechnique={setCurrentTechnique} filterCondition={filterCondition}/>
                            </Stack>
                        </Grid>
                        <Grid item xs={9}>
                            <Displayer
                                imageSrc={getCurrentImageUrl()}
                                currentindex={playStatus.currentIndex}
                                totalIndex={boundary.maxIndex}
                                isPlaying={isPlaying}
                            /> 
                        </Grid>
                        <Grid xsOffset={3} xs={9}>
                            <ControlPanel
                                goToNextIndex={goToNextIndex}
                                goToPrevIndex={goToPrevIndex}
                                goToNextCamera={goToNextCamera}
                                goToPrevCamera={goToPrevCamera}
                                goPlay={goPlay}
                                isPlaying={isPlaying}
                                canGoNextCamera={canGoNextCamera}
                                canGoPrevCamera={canGoPrevCamera}
                                canGoNextIndex={canGoNextIndex}
                                canGoPrevIndex={canGoPrevIndex}
                                playSpeed={playSpeed}
                                defaultSpeed={defaultSpeed}
                                currentCamera={playStatus.currentCamera}
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