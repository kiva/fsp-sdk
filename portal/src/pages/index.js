import React from 'react';
import clsx from 'clsx';
import Link from '@docusaurus/Link';
import useDocusaurusContext from '@docusaurus/useDocusaurusContext';
import Layout from '@theme/Layout';
import HomepageFeatures from '@site/src/components/HomepageFeatures';
import Translate, {translate} from '@docusaurus/Translate';

import styles from './index.module.css';

function HomepageHeader() {
    const appTitle = translate({message: 'Kiva Partner API', id: 'app-title'});
    const appTagLine = translate({message: 'Placing your loans in the Kiva Marketplace', id: 'app-tagline'});
    const tutorial = translate({message: 'Introduction Tutorial', id: 'app-tutorial-button'});

    return (
        <header className={clsx('hero hero--primary', styles.heroBanner)}>
          <div className="container">
            <h1 className="hero__title">{appTitle}</h1>
            <p className="hero__subtitle">{appTagLine}</p>
            <div className={styles.buttons}>
              <Link
                className="button button--secondary button--lg"
                to="/docs/overview">
                  {tutorial}️
              </Link>
            </div>
          </div>
        </header>
      );
}

export default function Home() {

    const appTitle = translate({message: 'Kiva Partner API', id: 'app-title'});

    return (
        <Layout
          title={`${appTitle}`}
          description="Description will go into a meta tag in <head />">
          <HomepageHeader />
          <main>
            <HomepageFeatures />
          </main>
        </Layout>
    );
}
