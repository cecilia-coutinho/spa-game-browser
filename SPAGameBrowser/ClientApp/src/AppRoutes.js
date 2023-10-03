import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Profile } from "./components/Profile";
import { Highscore } from "./components/Highscore";
import { Game } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Game />
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
