import Head from 'next/head'
import { withRouter } from 'next/router'
import classNames from 'classnames'
import SiteHeader from './SiteHeader'
import PageHeader from './PageHeader'
import Footer from './Footer'

// Syntax highlighting
import Lowlight from 'react-lowlight'
// https://github.com/isagalaev/highlight.js/tree/master/src/languages
import langFs from 'highlight.js/lib/languages/fsharp'
import langCs from 'highlight.js/lib/languages/cs'
import langJavascript from 'highlight.js/lib/languages/javascript'
import langJson from 'highlight.js/lib/languages/json'
import langXML from 'highlight.js/lib/languages/xml'
import langText from 'highlight.js/lib/languages/plaintext'
import useDrift, { DriftContext } from './useDrift'
Lowlight.registerLanguage('fsharp', langFs)
Lowlight.registerLanguage('fs', langFs)
Lowlight.registerLanguage('csharp', langCs)
Lowlight.registerLanguage('cs', langCs)
Lowlight.registerLanguage('javascript', langJavascript)
Lowlight.registerLanguage('json', langJson)
Lowlight.registerLanguage('xml', langXML)
Lowlight.registerLanguage('text', langText)

import { useState, ReactNode } from 'react'
import { useLunr } from 'react-lunr'
import { index, store } from '../public/search'
import SearchPage from './SearchPage'

type Props = Readonly<{
  name: string;
  title: string;
  className?: string | string[];
  router: any;
  children: ReactNode;
  noChat?: boolean;
}>

// Actual layout
const Layout = ({ name, title, className = [], router, children, noChat, ...rest }: Props) => {
  const [query, setQuery] = useState<string | null>(null)

  const drift = useDrift("gvi23z7y7p36", noChat, x => x)

  const results = useLunr(query, index, store),
        isSearching = query != null && query.length > 0

  return <div className={classNames(className, name || 'root')} {...rest}>
    <div className='page-wrapper'>
      <Head>
        <meta name="viewport" content="width=device-width, initial-scale=1" key="viewport" />
        <meta charSet="utf-8" key="charset" />
        <meta name="description" content="Logary is a logging, tracing and metric library for .Net and JS as well as a stand-alone, cloud-native log router/ingress called Rutta." key="description" />
        <meta name="author" content="Henrik Feldt" key="author" />
        <link rel="icon" type="image/png" href={require("../public/images/favicon-32x32.png")} sizes="32x32" key="favicon" />
        <link rel="icon" type="image/png" href={require("../public/images/favicon-64x64.png")} sizes="64x64" key="favicon-64x64" />
        <link rel="icon" type="image/png" href={require("../public/images/favicon-96x96.png")} sizes="96x96" key="favicon-96x96" />
        <link rel="icon" type="image/png" href={require("../public/images/icon-200x200.png")} sizes="200x200" key="icon-200x200" />
        <link rel="apple-touch-icon" sizes="200x200" href={require("../public/images/icon-200x200.png")} key="apple-touch-icon-200x200" />
        <link rel="apple-touch-icon" sizes="500x500" href={require("../public/images/icon-500x500.png")} key="apple-touch-icon-500x500" />
        <title>{title}</title>
      </Head>

      <DriftContext.Provider value={drift.current}>
        {router.pathname === "/"
          ? <SiteHeader query={query} setQuery={setQuery} />
          : <PageHeader title={title} query={query} setQuery={setQuery} />}
        {isSearching
          ? <SearchPage query={query} setQuery={setQuery} results={results} />
          : children}
        <Footer />
      </DriftContext.Provider>
    </div>
  </div>
}

export default withRouter(Layout)