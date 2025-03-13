import React from 'react';
import { Image, Text, RichText, Link } from '@sitecore-jss/sitecore-jss-react';
import { Field, ImageField, withDatasourceCheck, ComponentParams } from '@sitecore-jss/sitecore-jss-nextjs';
import { ComponentProps } from 'lib/component-props';

type InstagramProps = ComponentProps & {
  fields: {
    instagramTitle: Field<string>;
  };
};

const Instagram = ({fields}: InstagramProps): JSX.Element =>{

  return (
    <div className="col-lg-3 col-md-6">
      <div className="single-footer-widget">
        <Text tag="h3" field={fields.instagramTitle} />
        <ul id="Instafeed"></ul>
      </div>
    </div>
  )
}

export default withDatasourceCheck()<InstagramProps>(Instagram);


