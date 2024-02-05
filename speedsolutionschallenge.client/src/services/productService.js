const API_URL = "api/product";

const productService = {
    createProduct: async (product) => {
        try {
            const response = await fetch(`${API_URL}/create`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(product),
            });

            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(`Error al crear el producto: ${errorText}`);
            }

            return await response.json();
        } catch (error) {
            throw new Error(`Error al añadir el producto: ${error.message}`);
        }
    },

    getAllProducts: async () => {
        try {
            const response = await fetch(`${API_URL}/getAll`);
            return await response.json();
        } catch (error) {
            throw new Error(`Error al obtener la lista de productos: ${error.message}`);
        }
    },

    getProductById: async (productId) => {
        try {
            const response = await fetch(`${API_URL}/getById/${productId}`);
            return await response.json();
        } catch (error) {
            throw new Error(`Error al obtener el producto: ${error.message}`);
        }
    },

    updateProduct: async (productId, updatedProduct) => {
        try {
            const response = await fetch(`${API_URL}/update/${productId}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(updatedProduct),
            });

            return await response.json();
        } catch (error) {
            throw new Error(`Error al editar el producto: ${error.message}`);
        }
    },

    deleteProduct: async (productId) => {
        try {
            await fetch(`${API_URL}/delete/${productId}`, {
                method: "DELETE",
            });

            return true;
        } catch (error) {
            throw new Error(`Error al eliminar el producto: ${error.message}`);
        }
    },
};

export default productService;
