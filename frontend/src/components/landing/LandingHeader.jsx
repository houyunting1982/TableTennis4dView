import { Button, Grid, Menu, MenuItem, Typography } from '@mui/material';
import { Stack } from '@mui/system';
import React from 'react';
import KillerspinLogo from '../../asserts/images/killerspin-logo.svg';
import { useAuth } from '../../hooks/useAuth';
import { useHistory } from 'react-router-dom/cjs/react-router-dom.min';

const LandingHeader = () => {
    const { logout, userName } = useAuth();
    const history = useHistory();

    const [anchorEl, setAnchorEl] = React.useState(null);
    const open = Boolean(anchorEl);
    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = (category) => {
        history.push(`/admin/${category}`);
        setAnchorEl(null);
    };
    return (
        <Grid
            container
            spacing={2}
            sx={{
                marginTop: '20px',
                alignItems: 'center'
            }}
        >
            <Grid item xs={6} sx={{ textAlign: 'left' }}>
                <Stack direction='row' alignItems='center'>
                    <img
                        src={KillerspinLogo}
                        alt='Killerspin Logo'
                        width={100}
                        heigh={100}
                    />
                    <Typography variant='h2' color={'white'}>
                        4D
                    </Typography>
                </Stack>
            </Grid>
            <Grid item xs={6}>
                <Stack
                    direction='row'
                    alignItems='center'
                    justifyContent='flex-end'
                    spacing={6}
                >
                    <Typography variant='h5' color={'white'}>
                        Account: {userName}
                    </Typography>
                    <div>
                        <Typography variant='h5' color={'white'} onClick={handleClick} style={{cursor: 'pointer'}}>
                            Admin
                        </Typography>
                        <Menu
                            id="basic-menu"
                            anchorEl={anchorEl}
                            open={open}
                        >
                            <MenuItem onClick={() => handleClose('players')}>Players</MenuItem>
                            <MenuItem onClick={() => handleClose('techniques')}>Techniques</MenuItem>
                        </Menu>
                    </div>
                    <Typography
                        as={Button}
                        variant='h5'
                        color={'white'}
                        onClick={logout}
                    >
                        Log Out
                    </Typography>
                </Stack>
            </Grid>
        </Grid>
    );
};
export default LandingHeader;
