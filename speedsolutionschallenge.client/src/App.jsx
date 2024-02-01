import { Navigate, createBrowserRouter, RouterProvider, } from 'react-router-dom';
import Products from './views/Products/Products';
import HomeDashboard from './views/HomeDashboard/HomeDashboard';
import Home from './views/Home/Home';
import Prices from './views/Prices/Prices';
import DispenserManagement from './views/DispenserManagement/DispenserManagement';
import ViewDispensers from './views/ViewDispensers/ViewDispensers';
import ViewTransactions from './views/ViewTransactions/ViewTransactions';

const router = createBrowserRouter([
    {
        path: '/',
        element: <HomeDashboard />,
        children: [
            {
                path: '/',
                element: <Navigate to="/inicio" replace />,
            },
            {
                path: '/inicio',
                element: <Home />,
            },
            {
                path: '/productos',
                element: <Products />,
            },
            {
                path: '/precios',
                element: <Prices />,
            },
            {
                path: '/ControlDispensadores',
                element: <DispenserManagement />,
            },
            {
                path: '/VisualizacionDispensadores',
                element: <ViewDispensers />,
            },
            {
                path: '/VisualizacionTransacciones',
                element: <ViewTransactions />,
            },
        ],
    },
]);

function App() {
    return (
            <RouterProvider router={router} />
    );
}

export default App;
