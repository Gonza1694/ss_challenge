import styles from './button.module.scss';
import PropTypes from 'prop-types';
import { useButton } from '@react-aria/button';
import { useRef } from 'react';

const Button = ({ title, icon, color, className, onClick, ...props }) => {
  const buttonStylesClass = `${styles.buttonStyles} ${
    className ? className : ''
  } ${icon ? styles.hasIcon : ''} ${styles[color]}`;
  const ref = useRef();
  const { buttonProps } = useButton(props, ref);

  return (
    <button
      {...buttonProps}
      onClick={onClick}
      className={buttonStylesClass}
      data-testid="product-add-btn"
      ref={ref}
    >
      <span>{title ? title : ''}</span>
    </button>
  );
};

Button.propTypes = {
  title: PropTypes.string.isRequired,
  icon: PropTypes.oneOfType([
    PropTypes.string,
    PropTypes.object
  ]),
  className: PropTypes.string,
  color: PropTypes.oneOf(['red', 'blue', 'green']).isRequired,
};

Button.defaultProps = {
  icon: '',
  className: '',
};

export default Button;
