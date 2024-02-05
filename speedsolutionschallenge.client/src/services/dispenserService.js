const API_URL = 'api/dispenser';

const dispenserService = {
    createDispenser: async (dispenserData) => {
        try {
            const response = await fetch(`${API_URL}/create`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(dispenserData),
            });

            const data = await response.json();
            return data;
        } catch (error) {
            throw new Error(`Error al crear un dispensador: ${error.message}`);
        }
    },

    getAllDispensers: async () => {
        try {
            const response = await fetch(`${API_URL}/getAll`);
            const data = await response.json();
            return data;
        } catch (error) {
            throw new Error(`Error al obtener los dispensadores: ${error.message}`);
        }
    },

    getDispenserById: async (dispenserId) => {
        try {
            const response = await fetch(`${API_URL}/getById/${dispenserId}`);
            const data = await response.json();
            return data;
        } catch (error) {
            throw new Error(`Error al obtener el dispensador: ${error.message}`);
        }
    },

    updateDispenser: async (dispenserId, updatedDispenser) => {
        try {
            const response = await fetch(`${API_URL}/update/${dispenserId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(updatedDispenser),
            });

            const data = await response.json();
            return data;
        } catch (error) {
            throw new Error(`Error al actualizar el dispensador: ${error.message}`);
        }
    },
};

export default dispenserService;
