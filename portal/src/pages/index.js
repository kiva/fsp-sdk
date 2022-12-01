import React from 'react';
import clsx from 'clsx';
import Link from '@docusaurus/Link';
import useDocusaurusContext from '@docusaurus/useDocusaurusContext';
import Layout from '@theme/Layout';
import HomepageFeatures from '@site/src/components/HomepageFeatures';
import Translate, {translate} from '@docusaurus/Translate';

import styles from './index.module.css';

function HomepageHeader() {
    /*
    this does not work
    const {siteConfig} = useDocusaurusContext();
    const {appTitle} = translate({message: siteConfig.title, id: 'app-title'});
    const {appTagLine} = translate({message: siteConfig.tagline, id: 'app-tagline'});

    nor does this work

    const {appTitle} = translate({message: 'Kiva Partner API', id: 'app-title'});
    const {appTagLine} = translate({message: 'Placing your loans in the Kiva Marketplace', id: 'app-tagline'});
    const {tutorial} = translate({message: 'Introduction Tutorial - 15 min ⏱', id: 'app-tutorial-button'});

    console.log(appTitle);
    console.log(appTagLine);
    console.log(tutorial);
    */

    const {siteConfig} = useDocusaurusContext();
    return (
        <header className={clsx('hero hero--primary', styles.heroBanner)}>
          <div className="container">
            <h1 className="hero__title">{siteConfig.title}</h1>
            <p className="hero__subtitle">{siteConfig.description}</p>
            <div className={styles.buttons}>
              <Link
                className="button button--secondary button--lg"
                to="/docs/overview">
                  {translate({message: 'Introduction Tutorial - 15 min ⏱', id: 'app-tutorial-button'})}️
              </Link>
            </div>
          </div>
        </header>
      );
}

export default function Home() {
    const {siteConfig} = useDocusaurusContext();
    return (
        <Layout
          title={`${siteConfig.title}`}
          description="Description will go into a meta tag in <head />">
          <HomepageHeader />
          <main>
            <HomepageFeatures />
          </main>
        </Layout>
    );
}
