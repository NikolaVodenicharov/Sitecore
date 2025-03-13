import React from 'react';
import {
  Field,
  ImageField,
  LinkField,
  Placeholder,
  RichText,
  Text,
  withDatasourceCheck,
} from '@sitecore-jss/sitecore-jss-nextjs';
import { ComponentProps } from 'lib/component-props';

type MainFooterPlaceholderProps = ComponentProps & {

}

const MainFooterPlaceholder = ({ rendering }: MainFooterPlaceholderProps): JSX.Element => {
  return (
    <div className="footer-widget-area">
      <div className="container">
        <div className="row">
          <div className="col-lg-3 col-md-6">
            <Placeholder name="jss-main-footer-placeholder-1" rendering={rendering} />
          </div>
          <div className="col-lg-3 col-md-6">
            <Placeholder name="jss-main-footer-placeholder-2" rendering={rendering} />
          </div>
          <div className="col-lg-3 col-md-6">
            <Placeholder name="jss-main-footer-placeholder-3" rendering={rendering} />
          </div>
          <div className="col-lg-3 col-md-6">
            <Placeholder name="jss-main-footer-placeholder-4" rendering={rendering} />
          </div>
        </div>
      </div>
    </div>
  );
};

export default MainFooterPlaceholder;
