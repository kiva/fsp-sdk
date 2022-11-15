import React from 'react';
import clsx from 'clsx';
import styles from './styles.module.css';

const FeatureList = [
  {
    title: 'Ready to Integrate',
    Svg: require('@site/static/img/integrate.svg').default,
    description: (
      <>
        The Kiva Partner API was designed from the ground up to be integrated into existing financial systems
      </>
    ),
  },
  {
    title: 'Pre-made SDKs',
    Svg: require('@site/static/img/sdk.svg').default,
    description: (
      <>
        The API is supported by specialized SDKs that reduce the cost of integration. Go
        ahead and find the one that matches your existing tech stack.
      </>
    ),
  },
  {
    title: 'Close Customer Support',
    Svg: require('@site/static/img/support.svg').default,
    description: (
      <>
        Our product managers and engineers are on the ready to help your integration succeed.
      </>
    ),
  },
];

function Feature({Svg, title, description}) {
  return (
    <div className={clsx('col col--4')}>
      <div className="text--center">
        <Svg className={styles.featureSvg} role="img" />
      </div>
      <div className="text--center padding-horiz--md">
        <h3>{title}</h3>
        <p>{description}</p>
      </div>
    </div>
  );
}

export default function HomepageFeatures() {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="row">
          {FeatureList.map((props, idx) => (
            <Feature key={idx} {...props} />
          ))}
        </div>
      </div>
    </section>
  );
}
