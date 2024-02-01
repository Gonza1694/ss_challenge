import { Outlet } from 'react-router-dom';
import Header from '../../components/Header/Header';
import MainContent from '../../components/MainContent/MainContent';
import styles from './homedashboard.module.scss';
import Navbar from '../../components/Navbar/Navbar';

const HomeDashboard = () => {

  return (
      <div className={styles.container} data-testid="home-dashboard">
      <Header />
      <Navbar />
      <MainContent>
        <Outlet />
      </MainContent>
    </div>
  );
};

export default HomeDashboard;
