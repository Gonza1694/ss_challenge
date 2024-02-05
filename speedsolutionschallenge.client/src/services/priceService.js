const API_URL = "api/price";

const priceService = {
    createPrice: async (price) => {
        try {
            const response = await fetch(`${API_URL}/create`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(price),
            });

            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(`Error al crear el precio: ${errorText}`);
            }

            return await response.json();
        } catch (error) {
            throw new Error(`Error en la operación createPrice: ${error.message}`);
        }
    },

    getAllPrices: async () => {
        try {
            const response = await fetch(`${API_URL}/getAll`);

            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(`Error al obtener la lista de precios: ${errorText}`);
            }

            return await response.json();
        } catch (error) {
            throw new Error(`Error en la operación getAllPrices: ${error.message}`);
        }
    },

    updatePrice: async (priceId, price) => {
        try {
            const response = await fetch(`${API_URL}/update/${priceId}`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(price),
            });

            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(`Error al actualizar el precio: ${errorText}`);
            }

            return await response.json();
        } catch (error) {
            throw new Error(`Error en la operación updatePrice: ${error.message}`);
        }
    },
};

export default priceService;
