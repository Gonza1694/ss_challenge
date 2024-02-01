import React from 'react';
import styles from './header.module.scss';

const Header = ({ landingData }) => {
  React.useEffect(() => {
  }, [landingData]);

  return (
    <div className={styles.outerContainer}>
      <div className={styles.container}>
        <h1>Speed Solutions</h1>
      </div>
    </div>
  );
};

export default Header;
