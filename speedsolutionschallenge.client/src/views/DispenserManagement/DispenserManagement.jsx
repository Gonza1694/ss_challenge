import React, { useState, useEffect } from 'react';
import dispenserService from '../../services/dispenserService';
import productService from '../../services/productService';
import hoseService from '../../services/hoseService';
import styles from './dispensermanagement.module.scss';

const DispenserManagement = () => {
    const [products, setProducts] = useState([]);

    const [dispensers, setDispensers] = useState([]);
    const [dispenserName, setDispenserName] = useState('');
    const [hoseCount, setHoseCount] = useState('');
    const [editDispenser, setEditDispenser] = useState(null);

    const [hoses, setHoses] = useState([]);
    const [hoseName, setHoseName] = useState('');
    const [hoseDispenser, setHoseDispenser] = useState('');
    const [hoseProduct, setHoseProduct] = useState('');
    const [editHose, setEditHose] = useState(null);


    const fetchProducts = async () => {
        try {
            const allProducts = await productService.getAllProducts();
            setProducts(allProducts);
        } catch (error) {
            console.error('Error al obtener la lista de productos:', error.message);
        }
    };

    const fetchDispensers = async () => {
        try {
            const allDispensers = await dispenserService.getAllDispensers();
            setDispensers(allDispensers);
        } catch (error) {
            console.error('Error al obtener la lista de Dispensadores:', error.message);
        }
    };

    const fetchHoses = async () => {
        try {
            const allHoses = await hoseService.getAllHoses();
            setHoses(allHoses);
        } catch (error) {
            console.error('Error al obtener la lista de Mangueras:', error.message);
        }
    };

    const handleAddUpdateDispenserButton = async () => {
        try {
            if (editDispenser) {
                await dispenserService.updateDispenser(editDispenser.dispenserId, {
                    name: dispenserName,
                    hoseCount: hoseCount,
                });
            } else {
                await dispenserService.createDispenser({
                    name: dispenserName,
                    hoseCount: hoseCount,
                });
            }

            fetchDispensers();

            setDispenserName('');
            setHoseCount('');
            setEditDispenser(null);
        } catch (error) {
            console.error('Error al añadir/editar el dispensador:', error.message);
        }
    };

    const handleAddUpdateHoseButton = async () => {
        try {
            //TODO: Validar la cantidad de HoseCount antes de realizar el add/update

            if (editHose) {
                const otherHoses = hosesForDispenser.filter((hose) => hose.hoseId !== editHose.hoseId);
                if (otherHoses.length > selectedDispenser.hoseCount - 1) {
                    console.error('No se puede asociar más mangueras al dispensador. Se alcanzó el límite.');
                    return;
                }

                await hoseService.updateHose(editHose.hoseId, {
                    name: hoseName,
                    dispenserId: hoseDispenser,
                    productId: hoseProduct,
                });
            } else {
                if (hoseCountForDispenser >= selectedDispenser.hoseCount) {
                    console.error('No se puede asociar más mangueras al dispensador. Se alcanzó el límite.');
                    return;
                }

                await hoseService.createHose({
                    name: hoseName,
                    dispenserId: hoseDispenser,
                    productId: hoseProduct,
                });
            }

            fetchHoses();

            resetHoseForm();

            setEditHose(null);

        } catch (error) {
            console.error('Error al añadir/editar la manguera:', error.message);
        }
    };




    const handleEditDispenser = (dispenserId) => {
        const editedDispenser = dispensers.find((dispenser) => dispenser.dispenserId === dispenserId);
        setEditDispenser(editedDispenser);
        setDispenserName(editedDispenser.name);
        setHoseCount(editedDispenser.hoseCount);
    };

    const handleEditHose = (hoseId) => {
        const editedHose = hoses.find((hose) => hose.hoseId === hoseId);
        setEditHose(editedHose);
        setHoseName(editedHose.name);
        setHoseDispenser(editedHose.dispenserId);
        setHoseProduct(editedHose.productId);
    };

    const handleDeleteHose= async (hoseId) => {
        try {
            await hoseService.deleteHose(hoseId);

            const updatedHose= hoses.map((hose) =>
                hose.hoseID === hoseId ? { ...hose, isDeleted: true } : hose
            );

            setHoses(updatedHose);

            fetchHoses();
        } catch (error) {
            console.error('Error al eliminar el producto:', error.message);
        }
    };

    const resetHoseForm = () => {
        setHoseName('');
        setHoseDispenser('');
        setHoseProduct('');
    }

    useEffect(() => {
        fetchProducts();
        fetchHoses();
        fetchDispensers();
    }, []);

    return (
        <div className={styles.outerContainer}>
            <h2>Dispensadores</h2>
            <div className={styles.container}>
                <form className={styles.formContainer}>
                    <input
                        type="text"
                        placeholder="Nombre"
                        value={dispenserName}
                        onChange={(e) => setDispenserName(e.target.value)}
                        required
                    />
                    <input
                        type="number"
                        placeholder="Cantidad de Mangueras"
                        value={hoseCount}
                        onChange={(e) => setHoseCount(e.target.value)}
                        required
                    />
                    <button type="button" onClick={handleAddUpdateDispenserButton}>
                        {editDispenser ? 'Actualizar' : 'Añadir'}
                    </button>
                </form>
                <div className={styles.table}>
                    <table>
                        <thead>
                            <tr>
                                <th>Nombre</th>
                                <th>Mangueras</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            {dispensers.map((dispenser) => (
                                <tr key={dispenser.dispenserId}>
                                    <td>{dispenser.name}</td>
                                    <td>{dispenser.hoseCount}</td>
                                    <td>
                                        <button onClick={() => handleEditDispenser(dispenser.dispenserId)}>
                                            Editar
                                        </button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
            <h2>Mangueras</h2>
            <div className={styles.container}>
                <form className={styles.formContainer}>
                    <input
                        type="text"
                        placeholder="Nombre"
                        value={hoseName}
                        onChange={(e) => setHoseName(e.target.value)}
                        required
                    />

                    <select
                        value={hoseProduct}
                        onChange={(e) => setHoseProduct(e.target.value)}
                        required
                    >
                        <option value="" disabled>
                            Seleccionar producto
                        </option>
                        {products.map((product) =>
                            !product.isDeleted && (
                                <option key={product.productId} value={product.productId}>
                                    {product.name}
                                </option>
                            )
                        )}
                    </select>

                    <select
                        value={hoseDispenser}
                        onChange={(e) => {
                            setHoseDispenser(e.target.value);
                        }}
                        required
                    >
                        <option value="" disabled>
                            Seleccionar Dispenser
                        </option>
                        {dispensers.map((dispenser) => (
                            <option key={dispenser.dispenserId} value={dispenser.dispenserId}>
                                {dispenser.name}
                            </option>
                        ))}
                    </select>

                    <button type="button" onClick={handleAddUpdateHoseButton}>
                        {editHose ? 'Actualizar' : 'Añadir'}
                    </button>
                </form>
                <div className={styles.table}>
                    <table>
                        <thead>
                            <tr>
                                <th>Nombre</th>
                                <th>Dispenser</th>
                                <th>Producto</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            {hoses.map((hose) =>
                                !hose.isDeleted && (
                                <tr key={hose.hoseId}>
                                    <td>{hose.name}</td>
                                    <td>
                                        {dispensers.find((dispenser) => dispenser.dispenserId === hose.dispenserId)?.name || ''}
                                    </td>
                                    <td>
                                        {products.find((product) => product.productId === hose.productId)?.name || ''}
                                    </td>
                                    <td>
                                        <button onClick={() => handleEditHose(hose.hoseId)}>
                                            Editar
                                        </button>
                                            <button onClick={() => handleDeleteHose(hose.hoseId)}>
                                            Eliminar
                                        </button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
};

export default DispenserManagement;
