import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Highscore } from "./components/Highscore";
import { Home } from "./components/Home";
import GamePage from "./components/GamePage";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/game',
        requireAuth: true,
        element: <GamePage />
    },
    {
        path: '/highscore',
        requireAuth: false,
        element: <Highscore />
    },
    ...ApiAuthorzationRoutes
];

export default AppRoutes;
