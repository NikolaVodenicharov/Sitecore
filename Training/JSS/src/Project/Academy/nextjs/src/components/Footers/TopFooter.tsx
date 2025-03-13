import React from 'react';
import { Image, Text, RichText, Link } from '@sitecore-jss/sitecore-jss-react';
import { Field, ImageField, withDatasourceCheck, ComponentParams } from '@sitecore-jss/sitecore-jss-nextjs';
import { ComponentProps } from 'lib/component-props';

type TopFooterProps = ComponentProps & {
  fields: {
    topFooterTitle: Field<string>;
    topFooterSubTitle: Field<string>;
  };
};

const TopFooter = ({fields}: TopFooterProps): JSX.Element =>{

  return (
    <div className="newsletter-area">
      <div className="container">
        <div className="row">
          <div className="col-lg-5 col-md-5">
            <div className="newsletter-content">
              <Text tag="h2" field={fields.topFooterTitle} />
              <Text tag="h2" field={fields.topFooterSubTitle} />
            </div>
          </div>
          <div className="col-lg-7 col-md-7">
            <div className="newsletter-form angle">
              <form action="" method="post" id="mc-embedded-subscribe-form" name="mc-embedded-subscribe-form" className="mc-form footer-newsletter fix">
                <div className="subscribe-form">
                  <input id="mc-email" type="email" placeholder="Enter your email here"/>
                    <button id="mc-submit" type="submit">SUBSCRIBE</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default withDatasourceCheck()<TopFooterProps>(TopFooter);


