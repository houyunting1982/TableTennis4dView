import { Button, styled, Typography } from '@mui/material'
import { Stack } from '@mui/system'
import React, { useState, useEffect } from 'react'

import ArrowBackIosNewIcon from '@mui/icons-material/ArrowBackIosNew';
import ArrowForwardIosIcon from '@mui/icons-material/ArrowForwardIos';
import CameraAltIcon from '@mui/icons-material/CameraAlt';
import PlayCircleOutlineIcon from '@mui/icons-material/PlayCircleOutline';
import ArrowLeftIcon from '@mui/icons-material/ArrowLeft';
import ArrowRightIcon from '@mui/icons-material/ArrowRight';
import ReplayIcon from '@mui/icons-material/Replay';

const ControlButton = styled(Button)(({
    variant: 'outlined',
    width: "140px",
    opacity: 0.7,
    color: "#fff",
    border: 'solid 1px #fff',
    borderRadius: '0',
    padding: '6px 16px',
    "&:hover": {
        border: 'solid 1px #7a7676',
        backgroundColor: '#a4a4a4',
    },
    "&:disabled": {
        color: '#b1b1b1',
        border: 'solid 1px #b1b1b1',
        backgroundColor: '#363636',
        opacity: 0.5
    }
}));

const ActionLabel = styled(Typography)(({
    color: '#a4a4a4',
    width: '140px'
}));

const ControlPanel = ({
    goToNextIndex,
    goToPrevIndex,
    goToNextCamera,
    goToPrevCamera,
    goPlay,
    isPlaying,
    playSpeed,
    canGoNextCamera,
    canGoPrevCamera,
    canGoNextIndex,
    canGoPrevIndex,
    defaultSpeed,
    currentCamera
}) => {
    const [playStatus, setplayStatus] = useState(null);
    useEffect(() => {
        switch(playSpeed) {
            case defaultSpeed * 2:
                setplayStatus('FORWARD 50%')
                break;
            case defaultSpeed * 4:
                setplayStatus('FORWARD 25%')
                break;
            case defaultSpeed * 10:
                setplayStatus('FORWARD 10%')
                break;
            default:
                setplayStatus('FORWARD 100%')
                break;
        }
    }, [playSpeed, defaultSpeed])
    return (
        <>
            <Stack direction="row" spacing={2} justifyContent="space-evenly" alignItems="flex-end" sx={{ height: '2.5em' }}>
                <Stack>
                    <ControlButton color='inherit' onClick={() => goToPrevCamera()} disabled={canGoPrevCamera()}>
                        <ArrowBackIosNewIcon />
                        {!canGoPrevCamera() && <Typography variant='body1' sx={{ mx: 2 }}>{currentCamera}</Typography>}
                        <CameraAltIcon />
                    </ControlButton>
                </Stack>

                <Stack>
                    <ControlButton color='inherit' onClick={() => goToPrevIndex()} disabled={canGoPrevIndex()}>
                        <ArrowLeftIcon />
                    </ControlButton>
                </Stack>

                <Stack>
                    {playStatus && isPlaying && <ActionLabel variant='subtitle1'>{playStatus}</ActionLabel>}
                    <ControlButton variant={isPlaying ? "contained" : "outlined"} color='inherit' onClick={() => goPlay()}>
                        {
                            isPlaying ? <ReplayIcon sx={{ color: '#363636' }} /> :
                                <PlayCircleOutlineIcon />
                        }
                    </ControlButton>
                </Stack>

                <Stack>
                    <ControlButton color='inherit' onClick={() => goToNextIndex()} disabled={canGoNextIndex()}>
                        <ArrowRightIcon />
                    </ControlButton>
                </Stack>

                <Stack>
                    <ControlButton color='inherit' onClick={() => goToNextCamera()} disabled={canGoNextCamera()}>
                        <CameraAltIcon />
                        {!canGoNextCamera() && <Typography variant='body1' sx={{ mx: 2 }}>{currentCamera + 2}</Typography>}
                        <ArrowForwardIosIcon />
                    </ControlButton>
                </Stack>
            </Stack>
        </>
    )
}

export default ControlPanel