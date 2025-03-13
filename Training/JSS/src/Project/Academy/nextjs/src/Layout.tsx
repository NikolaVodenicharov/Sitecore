import React from 'react';
import Head from 'next/head';
import { Placeholder, LayoutServiceData, Field, HTMLLink } from '@sitecore-jss/sitecore-jss-nextjs';
import config from 'temp/config';
import Navigation from 'src/Navigation';
import Scripts from 'src/Scripts';
import 'bootstrap/dist/css/bootstrap.css';


// Prefix public assets with a public URL to enable compatibility with Sitecore editors.
// If you're not supporting Sitecore editors, you can remove this.
const publicUrl = config.publicUrl;

interface LayoutProps {
  layoutData: LayoutServiceData;
  headLinks: HTMLLink[];
}

interface RouteFields {
  [key: string]: unknown;
  pageTitle: Field;
}

const Layout = ({ layoutData, headLinks }: LayoutProps): JSX.Element => {
  const { route } = layoutData.sitecore;

  const fields = route?.fields as RouteFields;

  return (
    <>
      <Scripts />
      <Head>
        <title>{fields.pageTitle.value.toString() || 'Page'}</title>
        <link rel="icon" href={`${publicUrl}/favicon.ico`} />
        {headLinks.map((headLink) => (
          <link rel={headLink.rel} key={headLink.href} href={headLink.href} />
        ))}
      </Head>

        <div className="as-mainwrapper">
          <div className="big-white">
            <header>
              <div className="container">{route && <Placeholder name="jss-header" rendering={route} />}</div>
            </header>

            <div className="container">{route && <Placeholder name="jss-main" rendering={route} />}</div>

            <footer>
              <div className="container">{route && <Placeholder name="jss-footer" rendering={route} />}</div>
            </footer>
          </div>
        </div>
    </>
  );
};

export default Layout;
