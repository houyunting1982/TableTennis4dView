import React from 'react'
import NavBar from '../components/admin/NavBar'
import PlayerList from '../components/admin/player/PlayerList'
import { Switch, useRouteMatch } from 'react-router-dom';
import ProtectedRoute from '../components/route/ProtectedRoute';
import EditPlayer from '../components/admin/player/EditPlayer';
import CreatePlayer from '../components/admin/player/CreatePlayer';
import TechniqueList from '../components/admin/technique/TechniqueList';
import CreateTechnique from '../components/admin/technique/CreateTechnique';

const AdminPage = () => {
  let { path } = useRouteMatch();
  return (
    <div>
        <NavBar />
        <Switch>
            <ProtectedRoute exact path={`${path}/players`} component={PlayerList} />
            <ProtectedRoute exact path={`${path}/players/update/:id`} component={EditPlayer} />
            <ProtectedRoute exact path={`${path}/players/create`} component={CreatePlayer} />
            <ProtectedRoute exact path={`${path}/techniques`} component={TechniqueList} />
            <ProtectedRoute exact path={`${path}/techniques/create`} component={CreateTechnique} />
        </Switch>
    </div>
  )
}

export default AdminPage