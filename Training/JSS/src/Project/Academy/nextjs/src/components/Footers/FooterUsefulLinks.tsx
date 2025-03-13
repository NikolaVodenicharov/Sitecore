import React from 'react';
import { Image, Text, RichText, Link } from '@sitecore-jss/sitecore-jss-react';
import { Field, ImageField, withDatasourceCheck, ComponentParams } from '@sitecore-jss/sitecore-jss-nextjs';
import { ComponentProps } from 'lib/component-props';

type FooterLink = {
  fields: {
    name: Field<string>;
    link: Field<string>;
  }
}

type UsefulLinksProps = ComponentProps & {
  fields: {
    title: Field<string>;
    linksList: FooterLink[];
  };
};

const UsefulLinks = ({fields}: UsefulLinksProps): JSX.Element =>{
  const { linksList: footerLinkList } = fields;

  const renderLinks = (footerLinkItems: FooterLink[]): JSX.Element => {
    return (
      <div className='row'>
        {
          footerLinkItems.map((item) =>
            <li>
              <a href={item.fields.link.value}>{item.fields.name.value}</a>
            </li>
          )
        }
      </div>
    );
  }

  return (
    <div className="single-footer-widget">
      <h3>
        <Text tag="h3" field={fields.title} />
      </h3>
      <ul className="footer-list">
        {renderLinks(footerLinkList)}
      </ul>
    </div>
  )
}

export default withDatasourceCheck()<UsefulLinksProps>(UsefulLinks);


