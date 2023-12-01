import {
    Alert,
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
import { getAllPlayers, getAllPlayersSimple } from "../../../services/apis/playersApi";
import { useAuth } from "../../../hooks/useAuth";
import _ from 'lodash';
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import { getAllTechniques } from "../../../services/apis/techniquesApi";
const RootContainer = styled("div")({
    flexGrow: 1
});

const CustomizedContainer = styled(Container)(({ theme }) => ({
    marginTop: theme.spacing(2),
}));

const CustomizedPaper = styled(Paper)(({ theme }) => ({
    padding: theme.spacing(2),
    color: theme.palette.text.secondary
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

const TechniqueList = () => {
    const history = useHistory();
    const { token } = useAuth();
    const [techniques, setTechniques] = useState([]);
    const [playerOptions, setPlayerOptions] = useState([]);
    const [error, setError] = useState(null);
    const [isLoading, setIsLoading] = useState(false);

    const handleUpdateTechnique = id => {
        history.push("/admin/techniques/update/" + id);
    }

    const handleDeleteTechnique = async id => {
        //await deleteTechniquerById(id, token);
        setTechniques(_.reject(techniques, (technique) => technique.id === id));
    }
    const handleCreateTechnique = () => {
        history.push("/admin/techniques/create")
    }

    useEffect(() => {
        setIsLoading(true)
        setError(null);
        getAllTechniques(token)
            .then(techniquesData => {
                setTechniques(techniquesData.data)
            })
            .catch(err => {
                setError(err.message);
            })
            .finally(() => {
                setIsLoading(false);
            });
    }, [token, getAllTechniques, setError, setTechniques, setIsLoading]);

    useEffect(() => {
        getAllPlayersSimple(token)
            .then(res => {
                const playerOps = res.data.map(player => ({
                    id: player.id,
                    name: `${player.firstName} ${player.lastName}`
                }));
                setPlayerOptions(playerOps);
            })
            .catch(err => {
                setError(err.message);
            });
    }, [token]);

    const mapPlayer = (id) => {
        const player = _.find(playerOptions, {id: id})
        return player ? `${player.name}` : id;
    }

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
                                Techniques
                            </Typography>
                        </Box>
                        <Box>
                            <Link to="/admin/techniques/create">
                                <Button variant="contained" color="primary" onClick={handleCreateTechnique}>
                                    CREATE
                                </Button>
                            </Link>
                        </Box>
                    </Box>
                    <TableContainer component={Paper} >
                        <CustomizedTableWithTitle aria-label="players table">
                            <TableHead>
                                <TableRow>
                                    <TableHeadCell align="center">Player</TableHeadCell>
                                    <TableHeadCell align="left">Title</TableHeadCell>
                                    <TableHeadCell align="left">Source</TableHeadCell>
                                    <TableHeadCell align="center">Action</TableHeadCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    techniques.map(technique => (
                                        <CustomizedTableRow key={technique.id}>
                                            <TableCell align="center">{mapPlayer(technique.playerId)}</TableCell>
                                            <TableCell align="left">{technique.title}</TableCell>
                                            <TableCell align="left">{technique.sourcePath}</TableCell>        
                                            <TableCell align="center">
                                                <ButtonGroup color="primary" aria-label="outlined primary button group">
                                                    <Button onClick={() => handleUpdateTechnique(technique.id)}>Edit</Button>
                                                    <Button variant="contained" color="warning" onClick={() => handleDeleteTechnique(technique.id)}>Del</Button>
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
    )
}

export default TechniqueList