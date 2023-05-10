import { CircularProgress, styled } from "@mui/material";
import { Container, Stack } from "@mui/system";
import React, { useRef } from "react";

const Screen = styled('img')(({
    width: '100%',
    userSelect: 'none'
}));

const Displayer = ({
    imageSrc
}) => {
    const imageRef = useRef(null);
    return (
        <Stack>
            <Container sx={{ p: 3, position: 'relative' }}>
                {
                    imageSrc ?
                        <Screen
                            type='image'
                            id='img'
                            src={imageSrc}
                            alt="tabletennis"
                            ref={imageRef}
                            sx={{ cursor: 'none' }}
                        />
                        : <CircularProgress color="success" />
                }
            </Container>
        </Stack>
    );
};

export default Displayer;
