import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { About } from './pages/about/about';
import { Login } from './pages/login/login';
import { Register } from './pages/register/register';
import { Profile } from './pages/profile/profile';
import { Notfound } from './pages/notfound/notfound';
import { authGuard } from './guards/auth.guards';
import { Posts } from './pages/posts/posts';
export const routes: Routes = [

  {
    path:'',
    redirectTo:'home',
    pathMatch:'full'
  },

  {
    path:'home',
    component:Home
  },

  {
    path:'about',
    component:About
  },

  {
    path:'login',
    component:Login
  },

  {
    path:'register',
    component:Register
  },

  {
    path:'profile',
    component:Profile,
    canActivate:[authGuard]
  },
    {
    path:'posts',
    component:Posts
},

  {
    path:'**',
    component:Notfound
  }


];