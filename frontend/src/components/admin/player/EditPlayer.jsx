import React, { useEffect, useState } from 'react'
import { useHistory, useParams } from 'react-router-dom/cjs/react-router-dom.min';
import { getPlayerById, updatePlayer } from '../../../services/apis/playersApi';
import { useAuth } from '../../../hooks/useAuth';
import { Alert, Button, Container, FormControl, Grid, InputLabel, MenuItem, Paper, Select, Stack, TextField, Typography, styled } from '@mui/material';

const CustomizedPaper = styled(Paper)(({ theme }) => ({
    marginTop: theme.spacing(8),
    paddingBottom: theme.spacing(2),
    paddingTop: theme.spacing(2),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
}));

const PlayerForm = styled('div')(({ theme }) => ({
    width: '80%', // Fix IE 11 issue.
    marginTop: theme.spacing(3),
}));

const CustomizedButton = styled(Button)(({ theme }) => ({
    margin: theme.spacing(3, 1, 2),
}));

const EditPlayer = () => {
    const history = useHistory();
    const { token } = useAuth();
    const { id } = useParams();
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [nickName, setNickName] = useState('');
    const [sex, setSex] = useState('');
    const [dominantHand, setDominantHand] = useState('');
    const [ownership, setOwnerShip] = useState('');

    const [error, setError] = useState('');
    const [isLoading, setIsLoading] = useState(false);

    const validate = () => {
        if (!firstName || !lastName || !sex || !dominantHand || !ownership) {
            setError("Miss one or more required fields");
            return false;
        }
        return true;
    }

    useEffect(() => {
        setIsLoading(true);
        setError('');

        getPlayerById(id, token)
        .then(res => {
            const player = res.data;
            setFirstName(player.firstName);
            setLastName(player.lastName);
            setNickName(player.nickName);
            setSex(player.sex);
            setDominantHand(player.dominantHand);
            setOwnerShip(player.ownership);
        })
        .catch(err => setError(err))
        .finally(() => {
            setIsLoading(false);
        })
    }, [id, setFirstName, setLastName, setNickName, setSex, setDominantHand, setOwnerShip, setIsLoading]);

    const handleSubmit = async () => {
        setIsLoading(true);
        setError('')
        if (!validate()) {
            setIsLoading(false);
            return;
        }
        const updatedPlayer = {
            id: id,
            firstName,
            lastName,
            nickName,
            sex,
            dominantHand,
            ownership
        };
        try {
            await updatePlayer(updatedPlayer, token);
            history.push("/admin/players")
        }
        catch (ex) {
            setError(ex.message)
        }
        finally {
            setIsLoading(false);
        }
    }

    const handleCancel = () => {
        history.push("/admin/players");
    }

    return (
        <Container maxWidth="md">
            <CustomizedPaper>
                <Typography component='h1' variant='h5'>
                    {firstName} {lastName}
                </Typography>
                <PlayerForm>
                    <Grid container spacing={2}>
                        <Grid item xs={12}>
                            <TextField
                                name="firstName"
                                variant="outlined"
                                required
                                fullWidth
                                id="firstName"
                                label="First Name"
                                value={firstName}
                                onChange={(e) => setFirstName(e.target.value)}
                                autoFocus
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                name="lasttName"
                                variant="outlined"
                                required
                                fullWidth
                                id="lastName"
                                label="Last Name"
                                value={lastName}
                                onChange={(e) => setLastName(e.target.value)}
                                autoFocus
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                name="nickName"
                                variant="outlined"
                                fullWidth
                                id="nickName"
                                label="Nick Name"
                                value={nickName}
                                onChange={(e) => setNickName(e.target.value)}
                                autoFocus
                            />
                        </Grid>
                        <Grid item xs={4}>
                            <FormControl required fullWidth>
                                <InputLabel id="sex-label">Sex</InputLabel>
                                <Select
                                    required
                                    labelId="sex"
                                    id="sex"
                                    value={sex}
                                    label="Sex"
                                    onChange={(e) => setSex(e.target.value)}
                                >
                                    <MenuItem value={'Male'}>Male</MenuItem>
                                    <MenuItem value={'Female'}>Female</MenuItem>
                                    <MenuItem value={'Other'}>Other</MenuItem>
                                </Select>
                            </FormControl>
                        </Grid>
                        <Grid item xs={4}>
                            <FormControl required fullWidth>
                                <InputLabel id="dominantHand-label">Dominant Hand</InputLabel>
                                <Select
                                    required
                                    labelId="dominantHand"
                                    id="dominantHand"
                                    value={dominantHand}
                                    label="Dominant Hand"
                                    onChange={(e) => setDominantHand(e.target.value)}
                                >
                                    <MenuItem value={'Right'}>Right</MenuItem>
                                    <MenuItem value={'Left'}>Left</MenuItem>
                                    <MenuItem value={'Both'}>Both</MenuItem>
                                </Select>
                            </FormControl>
                        </Grid>
                        <Grid item xs={4}>
                            <FormControl required fullWidth>
                                <InputLabel id="ownership-label">Ownership</InputLabel>
                                <Select
                                    required
                                    labelId="ownership"
                                    id="ownership"
                                    value={ownership}
                                    label="Ownership"
                                    onChange={(e) => setOwnerShip(e.target.value)}
                                >
                                    <MenuItem value={'Official'}>Official</MenuItem>
                                    <MenuItem value={'Private'}>Private</MenuItem>
                                </Select>
                            </FormControl>
                        </Grid>
                    </Grid>
                    <Stack direction="row" justifyContent="space-between">
                        <CustomizedButton
                            fullWidth
                            type="text"
                            variant="contained"
                            color="primary"
                            disabled={isLoading}
                            onClick={handleSubmit}
                        >
                            Update
                        </CustomizedButton>
                        <CustomizedButton
                            fullWidth
                            type="text"
                            variant="contained"
                            color="warning"
                            disabled={isLoading}
                            onClick={handleCancel}
                        >
                            Cancel
                        </CustomizedButton>
                    </Stack>
                    {
                        error &&
                        <Alert severity="error">
                            {error}
                        </Alert>
                    }
                </PlayerForm>
            </CustomizedPaper>
        </Container>
    )
}

export default EditPlayer