import React, { useState, useEffect } from 'react';
import productService from '../../services/productService';
import styles from './Products.module.scss';

const Products = () => {
    const [productName, setProductName] = useState('');
    const [productType, setProductType] = useState('');
    const [unitType, setUnitType] = useState('');
    const [products, setProducts] = useState([]);
    const [editProduct, setEditProduct] = useState(null);

    const handleAddUpdateButton = async () => {
        try {
            if (editProduct) {
                await productService.updateProduct(editProduct.productId, {
                    name: productName,
                    productType: productType,
                    unit: unitType,
                });

                const updatedProducts = products.map((product) =>
                    product.productId === editProduct.productId
                        ? { ...product, name: productName, productType: productType, unit: unitType }
                        : product
                );

                setProducts(updatedProducts);
                setEditProduct(null);
            } else {
                const createdProduct = await productService.createProduct({
                    name: productName,
                    productType: productType,
                    unit: unitType,
                });

                setProducts([...products, createdProduct]);
            }

            setProductName('');
            setProductType('');
            setUnitType('');
        } catch (error) {
            console.error('Error al añadir/editar el producto:', error.message);
        }
    };

    const handleEditProduct = (productId) => {
        const productToEdit = products.find((product) => product.productId === productId);

        setEditProduct(productToEdit);

        setProductName(productToEdit.name);
        setProductType(productToEdit.productType);
        setUnitType(productToEdit.unit);
    };

    const handleDeleteProduct = async (productId) => {
        try {
            await productService.deleteProduct(productId);

            const updatedProducts = products.map((product) =>
                product.productId === productId ? { ...product, isDeleted: true } : product
            );

            setProducts(updatedProducts);
        } catch (error) {
            console.error('Error al eliminar el producto:', error.message);
        }
    };

    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const allProducts = await productService.getAllProducts();
                setProducts(allProducts);
            } catch (error) {
                console.error('Error al obtener la lista de productos:', error.message);
            }
        };

        fetchProducts();
    }, []);

    return (
        <div className={styles.outerContainer}>
            <h2>Productos</h2>

            <div className={styles.container}>
                <form className={styles.formContainer}>
                    <input
                        type="text"
                        placeholder="Añadir producto"
                        value={productName}
                        onChange={(e) => setProductName(e.target.value)}
                        required
                    />

                    <select value={productType} onChange={(e) => setProductType(e.target.value)} required>
                        <option value="" disabled>
                            Tipo de producto
                        </option>
                        <option value="Combustible">Combustible</option>
                        <option value="Lubricante">Lubricante</option>
                    </select>

                    <select value={unitType} onChange={(e) => setUnitType(e.target.value)} required>
                        <option value="" disabled>
                            Unidad
                        </option>
                        <option value="Galones">Galones</option>
                        <option value="Litros">Litros</option>
                    </select>

                    <button type="button" onClick={handleAddUpdateButton}>
                        {editProduct ? 'Actualizar' : 'Añadir'}
                    </button>
                </form>

                <div className={styles.table}>
                    <table>
                        <thead>
                            <tr>
                                <th>Nombre</th>
                                <th>Tipo</th>
                                <th>Unidad</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            {products.map(
                                (product) =>
                                    !product.isDeleted && (
                                        <tr key={product.productId}>
                                            <td>{product.name}</td>
                                            <td>{product.productType}</td>
                                            <td>{product.unit}</td>
                                            <td>
                                                <button onClick={() => handleEditProduct(product.productId)}>
                                                    Editar
                                                </button>
                                                <button onClick={() => handleDeleteProduct(product.productId)}>
                                                    Eliminar
                                                </button>
                                            </td>
                                        </tr>
                                    )
                            )}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
};

export default Products;
