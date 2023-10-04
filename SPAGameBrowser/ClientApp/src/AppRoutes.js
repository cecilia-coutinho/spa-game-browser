import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { UserBoard } from "./components/UserBoard";
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
        path: '/userboard',
        element: <UserBoard />
    },
    {
        path: '/highscore',
        requireAuth: true,
        element: <Highscore />
    },
    ...ApiAuthorzationRoutes
];

export default AppRoutes;
