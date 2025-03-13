import React from 'react';
import { Image, Text, RichText, Link } from '@sitecore-jss/sitecore-jss-react';
import { Field, ImageField, withDatasourceCheck, ComponentParams } from '@sitecore-jss/sitecore-jss-nextjs';
import { ComponentProps } from 'lib/component-props';

type TopFooterProps = ComponentProps & {
  fields: {
    socialsImage: ImageField;
    socialsDescription: Field<string>;
  };
};

const TopFooter = ({fields}: TopFooterProps): JSX.Element =>{

  return (
    <div className="single-footer-widget">
    <div className="footer-logo">
        <a href="#">
          <Image field={fields.socialsImage} />
        </a>
    </div>
    <p>
      <RichText field={fields.socialsDescription} />
    </p>
    <div className="social-icons">
        <a href="#"><i className="zmdi zmdi-facebook"></i></a>
        <a href="#"><i className="zmdi zmdi-rss"></i></a>
        <a href="#"><i className="zmdi zmdi-google-plus"></i></a>
        <a href="#"><i className="zmdi zmdi-pinterest"></i></a>
        <a href="#"><i className="zmdi zmdi-instagram"></i></a>
    </div>
</div>
  )
}

export default withDatasourceCheck()<TopFooterProps>(TopFooter);


