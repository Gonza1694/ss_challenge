import React, { useState, useEffect } from 'react';
import dispenserService from '../../services/dispenserService';
import productService from '../../services/productService';
import priceService from '../../services/priceService';
import hoseService from '../../services/hoseService';
import styles from './viewdispensers.module.scss';

const ViewDispensers = () => {
    const [products, setProducts] = useState([]);
    const [dispensers, setDispensers] = useState([]);
    const [hoses, setHoses] = useState([]);
    const [prices, setPrices] = useState([]);

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

    useEffect(() => {
        fetchProducts();
        fetchDispensers();
        fetchHoses();
        fetchPrices();
    }, []);

    return (
        <div className={styles.outerContainer}>
            <h2>Visualización de Dispensadores</h2>
            <div className={styles.container}>
                <div className={styles.cardContainer}>
                    {dispensers.map((dispenser, index) => (
                        <div key={`dispenser-${index}`} className={styles.card}>
                            <div className="dispenser-container">
                                <h2>{dispenser.name}</h2>
                                {hoses.map((hose, hoseIndex) => (
                                    hose.dispenserId === dispenser.dispenserId && (
                                        <div key={`hose-${hoseIndex}`} className={styles.hoseItem}>
                                            <h3>Manguera: {hose.name}</h3>

                                            <div className={styles.pricesContainer}>
                                                <h4>{products.find((product) => product.productId === hose.productId)?.name}</h4>
                                                {prices.map((price, priceIndex) =>
                                                    hose.productId === price.productId && (
                                                        <div key={`price-${priceIndex}`} className={styles.priceItem}>
                                                            <h5>${price.value}</h5>
                                                        </div>
                                                    ))}
                                            </div>
                                        </div>
                                    )
                                ))}
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
};

export default ViewDispensers;
