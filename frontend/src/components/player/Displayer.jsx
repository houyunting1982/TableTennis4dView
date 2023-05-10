import { CircularProgress, styled } from "@mui/material";
import { Container, Stack } from "@mui/system";
import React, { useRef } from "react";

const Screen = styled('img')(({
    width: '100%',
    userSelect: 'none'
}));

const Displayer = ({
    imageSrc,
    currentindex,
    totalIndex,
    isPlaying
}) => {
    const imageRef = useRef(null);
    const getOpacity = () => {
        if (!isPlaying) {
            return 1;
        }
        if (currentindex === 0 || totalIndex - currentindex === 0) {
            return 0.7;
        }
        if (currentindex === 1 || totalIndex - currentindex === 1) {
            return 0.7;
        }
        if (currentindex === 2 || totalIndex - currentindex === 2) {
            return 0.7;
        }
        if (currentindex === 3 || totalIndex - currentindex === 3) {
            return 0.8;
        }
        if (currentindex === 4 || totalIndex - currentindex === 4) {
            return 0.8;
        }
        if (currentindex === 5 || totalIndex - currentindex === 5) {
            return 0.8;
        }
        if (currentindex === 6 || totalIndex - currentindex === 6) {
            return 0.8;
        }
        if (currentindex === 7 || totalIndex - currentindex === 7) {
            return 0.9;
        }
        if (currentindex === 8 || totalIndex - currentindex === 8) {
            return 0.9;
        }
        if (currentindex === 9 || totalIndex - currentindex === 9) {
            return 0.9;
        }
        return 1;

    }
    return (
        <Stack>
            <Container sx={{ position: 'relative', p: "0 !important", backgroundColor: "#000000", width: "1091px", height: "614px" }}>
                {imageSrc ?
                    <Screen
                        type='image'
                        id='img'
                        src={imageSrc}
                        alt="tabletennis"
                        ref={imageRef}
                        sx={{ cursor: 'none', opacity: getOpacity() }}
                    />
                    : <CircularProgress size={60} sx={{ position: 'absolute', top: '50%', left: '50%' }} />}
            </Container>
        </Stack>
    );
};

export default Displayer;
