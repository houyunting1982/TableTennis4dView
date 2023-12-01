import {
    Box,
    Button,
    ButtonGroup,
    Container,
    Paper,
    styled,
    Table,
    TableBody,
    TableCell,
    tableCellClasses,
    TableContainer,
    TableHead,
    TableRow,
    Typography,
} from "@mui/material";
import { Link } from "react-router-dom";
import React, { useState, useEffect } from "react";
import { deletePlayerById, getAllPlayers } from "../../../services/apis/playersApi";
import { useAuth } from "../../../hooks/useAuth";
import _ from 'lodash';
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";

const RootContainer = styled("div")({
    flexGrow: 1,
});

const CustomizedContainer = styled(Container)(({ theme }) => ({
    marginTop: theme.spacing(2),
}));

const CustomizedPaper = styled(Paper)(({ theme }) => ({
    padding: theme.spacing(2),
    color: theme.palette.text.secondary,
}));

const CustomizedTableWithTitle = styled(Table)({
    flexGrow: 1,
});

const TableHeadCell = styled(TableCell)(({ theme }) => ({
    [`&.${tableCellClasses.head}`]: {
      backgroundColor: theme.palette.common.black,
      color: theme.palette.common.white,
    },
}));

const CustomizedTableRow = styled(TableRow)(({ theme }) => ({
    '&:nth-of-type(odd)': {
      backgroundColor: theme.palette.action.hover,
    },
    // hide last border
    '&:last-child td, &:last-child th': {
      border: 0,
    },
}));

const PlayerList = () => {
    const history = useHistory();
    const { token } = useAuth();
    const [players, setPlayers] = useState([]);
    const [error, setError] = useState(null);
    const [isLoading, setIsLoading] = useState(false);

    const handleUpdatePlayer = id => {
        history.push("/admin/players/update/" + id);
    }

    const handleDeletePlayer = async id => {
        await deletePlayerById(id, token);
        setPlayers(_.reject(players, (player) => player.id === id));
    }
    const handleCreatePlayer = () => {
        history.push("/admin/players/create")
    }

    useEffect(() => {
        setIsLoading(true)
        setError(null);

        getAllPlayers(token)
            .then(playersData => {
                setPlayers(playersData.data)
            })
            .catch(err => {
                setError(err)
            })
            .finally(() => {
                setIsLoading(false);
            });
    }, [getAllPlayers, setIsLoading, setError, setPlayers]);

    return (
        <RootContainer>
            <CustomizedContainer maxWidth="lg">
                <CustomizedPaper>
                    <Box display="flex">
                        <Box flexGrow={1}>
                            <Typography
                                component="h2"
                                variant="h6"
                                color="primary"
                                gutterBottom
                            >
                                Players
                            </Typography>
                        </Box>
                        <Box>
                            <Link to="/admin/players/create">
                                <Button variant="contained" color="primary" onClick={handleCreatePlayer}>
                                    CREATE
                                </Button>
                            </Link>
                        </Box>
                    </Box>
                    <TableContainer component={Paper} >
                        <CustomizedTableWithTitle aria-label="players table">
                            <TableHead>
                                <TableRow>
                                    {/* <TableHeadCell align="right">ID</TableHeadCell> */}
                                    <TableHeadCell align="center">FirstName</TableHeadCell>
                                    <TableHeadCell align="center">LastName</TableHeadCell>
                                    <TableHeadCell align="center">NickName</TableHeadCell>
                                    <TableHeadCell align="center">Sex</TableHeadCell>
                                    <TableHeadCell align="center">Dominant Hand</TableHeadCell>
                                    <TableHeadCell align="center">Ownership</TableHeadCell>
                                    <TableHeadCell align="center">Techniques</TableHeadCell>
                                    <TableHeadCell align="center">Action</TableHeadCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    players.map(player => (
                                        <CustomizedTableRow key={player.id}>
                                            {/* <TableCell align="right">{player.id}</TableCell> */}
                                            <TableCell align="center">{player.firstName}</TableCell>
                                            <TableCell align="center">{player.lastName}</TableCell>
                                            <TableCell align="center">{player.nickName}</TableCell>
                                            <TableCell align="center">{player.sex}</TableCell>
                                            <TableCell align="center">{player.dominantHand}</TableCell>
                                            <TableCell align="center">{player.ownership}</TableCell>
                                            <TableCell align="center">{player.techniqueCount}</TableCell>
                                            <TableCell align="center">
                                                <ButtonGroup color="primary" aria-label="outlined primary button group">
                                                    <Button onClick={() => handleUpdatePlayer(player.id)}>Edit</Button>
                                                    <Button variant="contained" color="warning" onClick={() => handleDeletePlayer(player.id)}>Del</Button>
                                                </ButtonGroup>
                                            </TableCell>
                                        </CustomizedTableRow>
                                    ))
                                }
                            </TableBody>
                        </CustomizedTableWithTitle>
                    </TableContainer>
                </CustomizedPaper>
            </CustomizedContainer>
        </RootContainer>
    );
};

export default PlayerList;
