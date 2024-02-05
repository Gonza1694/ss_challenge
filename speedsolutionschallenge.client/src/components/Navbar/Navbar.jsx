import React from 'react';
import styles from './navbar.module.scss';
import { useNavigate } from 'react-router-dom';

const Navbar = () => {
    const navigate = useNavigate();

    return (
        <div className={styles.container}>
            <div className={styles.innerContainer}>
                <ul className={styles.linkContainer}>
                    <li>
                        <button onClick={() => navigate('/inicio')}>Inicio</button>
                    </li>
                    <li>
                        <button onClick={() => navigate('/productos')}>Productos</button>
                    </li>
                    <li>
                        <button onClick={() => navigate('/precios')}>Precios</button>
                    </li>
                    <li>
                        <button onClick={() => navigate('/ControlDispensadores')}>Control de dispensadores</button>
                    </li>
                    <li>
                        <button onClick={() => navigate('/VisualizacionDispensadores')}>Visualizaci&oacute;n de dispensadores</button>
                    </li>
                    <li>
                        <button onClick={() => navigate('/VisualizacionTransacciones')}>Visualizaci&oacute;n de transacciones</button>
                    </li>
                </ul>
            </div>
        </div>
    );
};

export default Navbar;
