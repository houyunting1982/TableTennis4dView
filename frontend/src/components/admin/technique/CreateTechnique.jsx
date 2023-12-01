import React, { useState, useEffect } from 'react'
import { useHistory } from 'react-router-dom/cjs/react-router-dom.min';
import { getAllPlayersSimple } from '../../../services/apis/playersApi';
import { useAuth } from '../../../hooks/useAuth';
import { Alert, Button, Container, FormControl, Grid, InputLabel, MenuItem, Paper, Select, Stack, TextField, Typography, styled } from '@mui/material';
import { createTechnique } from '../../../services/apis/techniquesApi';
import CloudUploadIcon from '@mui/icons-material/CloudUpload';

const VisuallyHiddenInput = styled('input')({
  clip: 'rect(0 0 0 0)',
  clipPath: 'inset(50%)',
  height: 1,
  overflow: 'hidden',
  position: 'absolute',
  bottom: 0,
  left: 0,
  whiteSpace: 'nowrap',
  width: 1,
});

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

const CreateTechnique = () => {
    const history = useHistory();
    const { token } = useAuth();
    const [selectedFile, setSelectedFile] = useState();
    const [playerId, setPlayerId] = useState();
    const [title, setTilte] = useState();
    const [playerOptions, setPlayerOptions] = useState([]);

    const [error, setError] = useState('');
    const [isLoading, setIsLoading] = useState(false);
    const handleFileSelected= (e) => {
        //in case you wan to print the file selected
        //console.log(e.target.files[0]);
        console.log(e.target.files[0])
        setSelectedFile(e.target.files[0]);
    };
    const handleCancel = () => {
        history.push("/admin/techniques");
    }

    const validate = () => {
        if (!selectedFile || !playerId || !title) {
            setError("Miss one or more required fields");
            return false;
        }
        return true;
    }

    const handleSubmit = async () => {
        setIsLoading(true);
        setError('');
        if (!validate()) {
            setIsLoading(false);
            return;
        }
        const formData = new FormData();
        formData.append("file", selectedFile);
        formData.append("title", title);
        formData.append("playerId", playerId);
        try {
            await createTechnique(formData, token);
            history.push("/admin/techniques")
        }
        catch (ex) {
            setError(ex.message)
        }
        finally {
            setIsLoading(false);
        }
    }

    useEffect(() => {
        if (!token) {
            return;
        }
        setIsLoading(true)
        setError(null);

        getAllPlayersSimple(token)
            .then(res => {
                const playerOps = res.data.map(player => ({
                    id: player.id,
                    name: `${player.firstName} ${player.lastName}`
                }));
                console.log(playerOps);
                setPlayerOptions(playerOps);
            })
            .catch(err => {
                setError(err.message);
            })
            .finally(() => {
                setIsLoading(false);
            });
    }, [token]);

    return (
        <Container maxWidth="md">
            <CustomizedPaper>
                <Typography component='h1' variant='h5'>
                    Create
                </Typography>
                <PlayerForm>
                    <Grid container spacing={2}>
                        <Grid item xs={12}>
                            <TextField
                                name="title"
                                variant="outlined"
                                required
                                fullWidth
                                id="title"
                                label="Title"
                                value={title}
                                onChange={(e) => setTilte(e.target.value)}
                                autoFocus
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <FormControl required fullWidth>
                                <InputLabel id="player-label">Player</InputLabel>
                                <Select
                                    required
                                    labelId="player"
                                    id="player"
                                    value={playerId}
                                    label="player"
                                    onChange={(e) => setPlayerId(e.target.value)}
                                >
                                    {
                                        playerOptions.map(op => (
                                            <MenuItem key={op.id} value={op.id}>{op.name}</MenuItem>
                                        ))
                                    }
                                </Select>
                            </FormControl>
                        </Grid>
                        <Grid item xs={4}>
                            <Button component="label" variant="contained" startIcon={<CloudUploadIcon />}>
                                Upload file
                                <VisuallyHiddenInput type="file" onChange={handleFileSelected}/>
                            </Button>
                        </Grid>
                        <Grid item xs={8}>
                        <Typography variant='h6'>
                            {selectedFile?.name}
                        </Typography>
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
                            Create
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

export default CreateTechnique