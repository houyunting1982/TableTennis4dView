import React from 'react'
import { Stack } from '@mui/system'
import { styled } from '@mui/material/styles';
import { Box, Button, InputAdornment, TextField } from '@mui/material';

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
    width: '260px',
    height: '320px',
    overflow: 'auto',
    backgroundColor: '#1A2027',
    padding: '10px',
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

const Sidebar = ({ techniques, setCurrentTechnique, selectedTechnique, filterCondition }) => {
    const handleClick = (e) => {
        setCurrentTechnique(e.target.value)
    }
    if (filterCondition) {
        techniques = techniques.filter(t => t.title.toLowerCase().includes(filterCondition.toLowerCase()));
    }
    return (
        <Holder>
            <Stack spacing={1}>
                {
                    techniques.map(technique =>
                        selectedTechnique.id === technique.id ?
                            <Item
                                key={technique.id} 
                                sx={{
                                    background: 'linear-gradient(0deg, #363636 0%, #b1b1b1 100%)',
                                    filter: 'invert(0.85)',
                                    color: 'white',
                                    cursor: "auto"
                                }}
                            >{technique.title}</Item>
                            : <Item onClick={handleClick} value={technique.id} key={technique.id}>{technique.title}</Item>)
                }
            </Stack>
        </Holder>
    )
}

export default Sidebar