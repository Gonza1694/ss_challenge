const apiUrl = "api/hose";

const hoseService = {
    createHose: async (hose) => {
        try {
            const response = await fetch(`${apiUrl}/create`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(hose),
            });

            if (!response.ok) {
                throw new Error(`Error al añadir la manguera. Código de estado: ${response.status}`);
            }

            return await response.json();
        } catch (error) {
            throw new Error(`Error al añadir la manguera: ${error.message}`);
        }
    },

    getAllHoses: async () => {
        try {
            const response = await fetch(`${apiUrl}/getAll`);
            return await response.json();
        } catch (error) {
            throw new Error(`Error al obtener las mangueras: ${error.message}`);
        }
    },

    getHoseById: async (hoseId) => {
        try {
            const response = await fetch(`${apiUrl}/getById/${hoseId}`);
            return await response.json();
        } catch (error) {
            throw new Error(`Error al obtener la manguera: ${error.message}`);
        }
    },

    updateHose: async (hoseId, updatedHose) => {
        try {
            const response = await fetch(`${apiUrl}/update/${hoseId}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(updatedHose),
            });

            if (!response.ok) {
                throw new Error(`Error actualizando la manguera. Código de estado: ${response.status}`);
            }

            return await response.json();
        } catch (error) {
            throw new Error(`Error actualizando la manguera: ${error.message}`);
        }
    },

    deleteHose: async (hoseId) => {
        try {
            await fetch(`${apiUrl}/delete/${hoseId}`, {
                method: "DELETE",
            });

            return true;
        } catch (error) {
            throw new Error(`Error al eliminar la manguera: ${error.message}`);
        }
    },
};

export default hoseService;
