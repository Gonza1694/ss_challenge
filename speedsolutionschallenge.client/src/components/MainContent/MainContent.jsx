import styles from "./maincontent.module.scss";

const MainContent = ({ children }) => {
    return (
        <div className={styles.outerContainer}>
            <div className={styles.container}>{children}</div>
        </div>
    );
};

export default MainContent;
