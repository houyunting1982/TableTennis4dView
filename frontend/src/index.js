import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import PlayPage from './pages/PlayPage';
import LandingPage from './pages/LandingPage';
import LoginPage from './pages/LoginPage';
import { AuthProvider } from './hooks/useAuth';
import ProtectedRoute from './components/route/ProtectedRoute';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <Router basename={`/${process.env.PUBLIC_URL}`}>
            <AuthProvider>
                <Switch>
                    <Route exact path='/login'>
                        <LoginPage />
                    </Route>
                    <ProtectedRoute exact path='/' component={LandingPage} />
                    <ProtectedRoute
                        exact
                        path='/technique/:playerId'
                        component={PlayPage}
                    />
                </Switch>
            </AuthProvider>
        </Router>
    </React.StrictMode>
);
