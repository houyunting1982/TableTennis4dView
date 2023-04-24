import React from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
// import FormControlLabel from '@mui/material/FormControlLabel';
// import Checkbox from '@mui/material/Checkbox';
// import Link from '@mui/material/Link';
// import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { styled } from '@mui/material/styles';
import { useAuth } from '../hooks/useAuth';
import { Redirect } from 'react-router-dom';

const LogInTextField = styled(TextField)({
    input: { color: '#010101' },
    backgroundColor: 'lightgray',
    borderRadius: '5px'
});

const LoginPage = () => {
    const { login, authed } = useAuth();
    const handleSubmit = (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);
        console.log({
            username: data.get('username'),
            password: data.get('password')
        });
        login(data.get('username'), data.get('password'));
    };

    return authed ? (
        <Redirect to='/' />
    ) : (
        <Container component='main' maxWidth='xs'>
            <Box
                sx={{
                    marginTop: 20,
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                    padding: '10px 20px',
                    backgroundColor: 'rgba(128, 139, 150, 0.7)',
                    borderRadius: '10px'
                }}
            >
                <Typography component='h1' variant='h5' color={'white'}>
                    4D Viewer
                </Typography>
                <Box
                    component='form'
                    onSubmit={handleSubmit}
                    noValidate
                    sx={{ mt: 1 }}
                >
                    <LogInTextField
                        margin='normal'
                        required
                        fullWidth
                        id='username'
                        name='username'
                        autoComplete='off'
                        placeholder='Username'
                        autoFocus
                    />
                    <LogInTextField
                        margin='normal'
                        required
                        fullWidth
                        name='password'
                        type='password'
                        id='password'
                        placeholder='Password'
                        autoComplete='off'
                    />
                    {/* <FormControlLabel
                        control={<Checkbox value='remember' color='primary' />}
                        label='Remember me'
                    /> */}
                    <Button
                        type='submit'
                        fullWidth
                        variant='contained'
                        sx={{ py: 1.5, my: 2 }}
                    >
                        Sign In
                    </Button>
                    {/* <Grid container>
                        <Grid item xs>
                            <Link href='#' variant='body2'>
                                Forgot password?
                            </Link>
                        </Grid>
                        <Grid item>
                            <Link href='#' variant='body2'>
                                {"Don't have an account? Sign Up"}
                            </Link>
                        </Grid>
                    </Grid> */}
                </Box>
            </Box>
        </Container>
    );
};

export default LoginPage;
