import { useState, useEffect } from 'react';
import { CircularProgress, Stack } from '@mui/material';
import { styled } from '@mui/material/styles';
import Grid from '@mui/material/Unstable_Grid2';
import LandingHeader from '../components/landing/LandingHeader';
import LandingSidebar from '../components/landing/LandingSidebar';
import { useAuth } from '../hooks/useAuth';
import { getUserDetail } from '../services/apis/usersApi';
import { getUnPurchasedPlayers } from '../services/apis/playersApi';

const Container = styled(Stack)({
    textAlign: 'center',
    maxWidth: '1600px',
    minWidth: '1200px',
    margin: '100px auto',
    padding: '0 50px'
});
const LandingPage = () => {
    const { userId, token } = useAuth();
    const [userDetail, setUserDetail] = useState(null);
    const [unpurchasedPlayers, setUnpurchasedPlayers] = useState([]);

    useEffect(() => {
        getUserDetail(userId, token).then((data) => {
            setUserDetail(data.data)
        });
        getUnPurchasedPlayers(userId, token).then((data) => {
            setUnpurchasedPlayers(data.data);
        })
    }, [token, userId, setUserDetail, setUnpurchasedPlayers]);
    return (
        <Container>
            <LandingHeader />
            {
                userDetail ?
                    <Grid
                        container
                        spacing={2}
                        sx={{
                            marginTop: '20px',
                            alignItems: 'center'
                        }}
                    >
                        <Grid item xs={6}>
                            <LandingSidebar
                                title={'Available Content:'}
                                players={unpurchasedPlayers}
                                allowpurchase={true}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <LandingSidebar
                                title={'My Content:'}
                                players={userDetail.players}
                                allowpurchase={false}
                            />
                        </Grid>

                    </Grid>
                    :
                    <Stack alignItems='center' justifyContent='center' sx={{ marginTop: 6, height: '500px' }}>
                        <CircularProgress size={60} />
                    </Stack>
            }

        </Container>
    );
};

export default LandingPage;
