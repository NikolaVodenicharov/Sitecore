import React from 'react';
import { Image, Text, RichText, Link } from '@sitecore-jss/sitecore-jss-react';
import { Field, ImageField, withDatasourceCheck, ComponentParams } from '@sitecore-jss/sitecore-jss-nextjs';
import { ComponentProps } from 'lib/component-props';

type BottomFooterProps = ComponentProps & {
  fields: {
    bottomFooterCopyright: Field<string>;
    bottomFooterTerms: Field<string>;
  };
};

const BottomFooter = ({fields}: BottomFooterProps): JSX.Element =>{

  return (
    <div className="footer-area">
      <div className="container">
        <div className="row">
          <div className="col-lg-6 col-md-7 col-12">
            <span>
              <Text field={fields.bottomFooterCopyright} />
            </span>
          </div>
          <div className="col-lg-6 col-md-5 col-12">
            <div className="column-right">
              <span>
                <Text field={fields.bottomFooterTerms} />
              </span>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default withDatasourceCheck()<BottomFooterProps>(BottomFooter);


