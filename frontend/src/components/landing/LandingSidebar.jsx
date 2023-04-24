import React, { useState } from 'react'
import { Stack } from '@mui/system'
import { styled } from '@mui/material/styles';
import { Box, Button, Modal, Typography } from '@mui/material';
import { Link } from 'react-router-dom';
import { useAuth } from '../../hooks/useAuth';
import { AddPlayerToUser } from '../../services/apis/usersApi';
import { useHistory } from "react-router-dom";

const Item = styled(Button)(({ theme }) => ({
    background: 'linear-gradient(0deg, #363636 0%, #b1b1b1 100%)',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: '#fff',
    fontWeight: 'bold',
    fontSize: '1em',
    textTransform: 'none',
    '&:hover': {
        background: 'linear-gradient(0deg, #363636 0%, #b1b1b1 100%)',
        filter: 'invert(0.85)'
    }
}));

const Holder = styled(Box)({
    width: '60%',
    height: '400px',
    overflow: 'auto',
    backgroundColor: '#1A2027',
    padding: '10px',
    margin: '10px auto',
    border: '2px solid #fff',
    cursor: 'pointer',
    '&::-webkit-scrollbar': {
        width: '20px',
    },
    '&::-webkit-scrollbar-track': {
        backgroundColor: 'lightgrey',
        boxShadow: 'inset 0 0 6px #eccaca4c;',
        borderRight: '3px solid #1A2027'
    },
    '&::-webkit-scrollbar-thumb': {
        backgroundColor: 'grey',
        boxShadow: 'inset 0 0 6px #eae2e27f',
        borderRight: '3px solid #1A2027'
    },
    '&::-webkit-scrollbar-thumb:hover': {
        backgroundColor: '#616060',
    }
})

const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: '#111111',
    color: "#dddddd",
    border: '2px solid #aaaaaa',
    boxShadow: 24,
    p: 4,
};


const LandingSidebar = ({ title, players, allowpurchase }) => {
    let history = useHistory();
    const { userId, token } = useAuth();
    const handlePurchase = async () => {
        await AddPlayerToUser(userId, selectedPlayer.id, token);
        setOpen(false);
        history.push("/login") /*It's a trick, will remove it soon*/
    }
    const [open, setOpen] = useState(false);
    const [selectedPlayer, setSelectedPlayer] = useState(null)
    const handleOpen = (player) => {
        setSelectedPlayer(player);
        setOpen(true);
    }
    const handleClose = () => setOpen(false);
    return (
        <>
            <Typography variant='h4' color='white'>
                {title}
            </Typography>
            <Holder>
                <Stack spacing={1}>
                    {
                        players.map(player => (
                            allowpurchase ?
                                <Item value={player.id} key={player.id} onClick={(e) => handleOpen(player)}>
                                    {player.firstName} {player.lastName} - {player.techniqueCount} techniques
                                </Item>
                                : <Item value={player.id} key={player.id} as={Link} to={`/technique/${player.id}`} >
                                    {player.firstName} {player.lastName} - {player.techniqueCount} techniques
                                </Item>
                        ))
                    }
                </Stack>
            </Holder>

            <Modal
                open={open}
                onClose={handleClose}
            >
                <Box sx={style}>
                    <Typography id="modal-modal-title" variant="h6" component="h2">
                        Confirm Your Purchase
                    </Typography>
                    <Typography id="modal-modal-description" sx={{ my: 2 }}>
                        You are purchasing {selectedPlayer?.firstName} {selectedPlayer?.lastName} - {selectedPlayer?.techniqueCount}
                    </Typography>
                    <Stack justifyContent="flex-end" direction="row" spacing={2}>
                        <Button variant="contained" color="success" onClick={handlePurchase}>
                            Ok
                        </Button>
                        <Button variant="contained" color='error' onClick={handleClose}>
                            Cancel
                        </Button>
                    </Stack>
                </Box>
            </Modal>
        </>

    )
}

export default LandingSidebar