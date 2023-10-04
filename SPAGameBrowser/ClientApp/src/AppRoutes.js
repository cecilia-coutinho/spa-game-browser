import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Profile } from "./components/Profile";
import { Highscore } from "./components/Highscore";
import { Home } from "./components/Home";
import { GamePage } from "./components/GamePage";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/game',
        element: <GamePage />
    },
    {
        path: '/profile',
        element: <Profile />
    },
    {
        path: '/highscore',
        requireAuth: true,
        element: <Highscore />
    },
    ...ApiAuthorzationRoutes
];

export default AppRoutes;
