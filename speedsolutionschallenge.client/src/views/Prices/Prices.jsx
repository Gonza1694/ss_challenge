import React, { useState, useEffect } from 'react';
import priceService from '../../services/priceService';
import productService from '../../services/productService';
import styles from './Prices.module.scss';

const Prices = () => {
    const [selectedProduct, setSelectedProduct] = useState('');
    const [products, setProducts] = useState([]);

    const [prices, setPrices] = useState([]);
    const [priceValue, setPriceValue] = useState('');
    const [editingPrice, setEditingPrice] = useState(false);
    const [editedPrice, setEditedPrice] = useState(null);

    const handleAddPrice = async () => {
        try {
            if (editingPrice) {
                const currentDate = new Date();
                const formattedDate = currentDate.toISOString();

                await priceService.updatePrice(editedPrice.priceId, {
                    value: priceValue,
                    productId: selectedProduct,
                    date: formattedDate,
                });

                const updatedPrices = prices.map((price) =>
                    price.priceId === editedPrice.priceId
                        ? { ...price, value: priceValue, productId: selectedProduct, date: formattedDate }
                        : price
                );

                setPrices(updatedPrices);

                setEditingPrice(false);
                setEditedPrice(null);
            } else {
                const currentDate = new Date();
                const formattedDate = currentDate.toISOString();

                const createdPrice = await priceService.createPrice({
                    value: priceValue,
                    productId: selectedProduct,
                    date: formattedDate,
                });

                setPrices([...prices, createdPrice]);
            }

            setPriceValue('');
            setSelectedProduct('');
        } catch (error) {
            console.error('Error al añadir/editar el precio:', error.message);
        }
    };


    const handleEditPrice = (price) => {
        setEditingPrice(true);
        setEditedPrice(price);

        setPriceValue(price.value);
        setSelectedProduct(price.productId);

        const currentDate = new Date();
        const formattedDate = currentDate.toISOString();
        setEditedPrice({ ...price, date: formattedDate });
    };

    const fetchProducts = async () => {
        try {
            const allProducts = await productService.getAllProducts();
            setProducts(allProducts);
        } catch (error) {
            console.error('Error al obtener la lista de productos:', error.message);
        }
    };

    const fetchPrices = async () => {
        try {
            const allPrices = await priceService.getAllPrices();
            setPrices(allPrices);
        } catch (error) {
            console.error('Error al obtener la lista de precios:', error.message);
        }
    };

    const getProductName = (productId) => {
        const product = products.find((product) => product.productId === productId);
        return product ? product.name : 'Producto no encontrado';
    };

    const formatDate = (dateString) => {
        const options = { year: 'numeric', month: 'numeric', day: 'numeric' };
        return new Date(dateString).toLocaleDateString(undefined, options);
    };

    const isProductDeleted = (productId) => {
        const product = products.find((product) => product.productId === productId);
        return product ? product.isDeleted : false;
    }

    useEffect(() => {
        fetchProducts();
        fetchPrices();
    }, []);

    return (
        <div className={styles.outerContainer}>
            <h2>Precios</h2>

            <div className={styles.container}>
                <form className={styles.formContainer}>
                    <input
                        type="number"
                        placeholder="Agregar precio"
                        value={priceValue}
                        onChange={(e) => setPriceValue(e.target.value)}
                        required
                    />

                    <select
                        value={selectedProduct}
                        onChange={(e) => setSelectedProduct(e.target.value)}
                        required
                    >
                        <option value="" disabled>
                            Seleccionar producto
                        </option>
                        {products.map((product) =>
                            !product.isDeleted &&                        (
                            <option key={product.productId} value={product.productId}>
                                {product.name}
                            </option>
                        ))}
                    </select>

                    <button type="button" onClick={handleAddPrice}>
                        {editingPrice ? 'Actualizar' : 'Añadir'}
                    </button>
                </form>

                <div className={styles.table}>
                    <table>
                        <thead>
                            <tr>
                                <th>Valor</th>
                                <th>Producto</th>
                                <th>Fecha</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            {prices
                                .filter((price) => !isProductDeleted(price.productId))
                                .map((price) => (
                                    <tr key={price.priceId}>
                                        <td>{price.value}</td>
                                        <td>{getProductName(price.productId)}</td>
                                        <td>{formatDate(price.date)}</td>
                                        <td>
                                            <button onClick={() => handleEditPrice(price)}>
                                                Editar
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

export default Prices;
