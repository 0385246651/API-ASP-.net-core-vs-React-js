import logo from './logo.svg';
import './App.css';
import Button from 'react-bootstrap/Button';

import {Home} from './Components/Home';
import {Department} from './Components/Department';
import {Employee} from './Components/Employee';
import {Navigation} from './Components/Navigation';

import {BrowserRouter, Route, Switch } from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="Container">
      <h3 className='m-3 d-flex justify-content-center'>Hello guys ! This is a Ex about React to Api to  My SQL</h3>

      <Navigation/>

      <Switch>
        <Route path="/" component={Home} exact/>
        <Route path="/department" component={Department} exact/>
        <Route path="/employee" component={Employee} exact/>

      </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
