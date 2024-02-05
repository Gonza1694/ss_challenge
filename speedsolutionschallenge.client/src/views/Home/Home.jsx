import React from 'react'
import styles from './home.module.scss'

const Home = () => {
  return (
      <div className={styles.outerContainer}>
            <h2>Inicio</h2>
          <div className={styles.container}>
              <article>
                  <h3>Módulos</h3>

                  <li>Productos</li>

                  Permite agregar, consultar, listar, modificar y borrar productos.

                  <li>Precios</li>

                  Permite agregar, consultar y listar precios asociados a productos.

                  <li>Control de Dispensadores</li>

                  Permite la creación, listado y modificación de dispensadores.

                  <li>Mangueras</li>

                  Permite la creación, listado, modificación y borrado de mangueras.

                  <li>Visualización de Dispensadores</li>

                  Se visualiza la configuración del surtidor, precios asignados, volumen, dinero, etc.

                  <li>Visualización de Transacciones</li>

                  Interfaz que muestra un listado de las ventas realizadas.
                  Permite filtrar por rango de fechas y organiza el listado de forma descendente.

              </article>              
      </div>
    </div>
  )
}

export default Home