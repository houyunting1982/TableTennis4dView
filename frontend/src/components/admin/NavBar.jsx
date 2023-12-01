import { AppBar, IconButton, styled, Toolbar, Typography } from '@mui/material'
import { Link } from "react-router-dom";
import MenuIcon from '@mui/icons-material/Menu';
import React from 'react'
import KillerspinLogo from '../../asserts/images/killerspin-logo.svg';

const Container = styled('div')({
    flexGrow: 1
});

const CustomizedIconButton = styled(IconButton)(({theme}) => ({
    marginRight: theme.spacing(2),
}));

const NavLink = styled(Link)({
    color: 'white',
    textDecoration: 'none'
})

const Title = styled(Typography) ({
    flexGrow: 1,
    cursor: 'pointer'
})

const CustomizedAppBar = styled(AppBar)({
    backgroundColor: 'grey'
})

const NavBar = () => {
  return (
    <Container>
        <CustomizedAppBar position='static'>
            <Toolbar>
                <CustomizedIconButton dge="start" color="inherit" aria-label="menu" as={Link} to='/'>
                    <img src={KillerspinLogo} alt="Killerspin Logo" width={100} heigh={100} />
                </CustomizedIconButton>
                <NavLink to='/'>
                    <Title variant='h6'>
                        TT 4D Admin
                    </Title>
                </NavLink>
            </Toolbar>
        </CustomizedAppBar>
    </Container>
  )
}

export default NavBar