import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";


@Injectable()
export class AutorizacijaVodicProvjera implements CanActivate {

  constructor(private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    try {
      if (AutentifikacijaHelper.getLoginInfo().isPermisijaAdmin || AutentifikacijaHelper.getLoginInfo().isPermisijaVodic)
        return true;
    }
    catch (e){}
    // not logged in so redirect to login page with the return url
    this.router.navigate(['/login'], {queryParams: {returnUrl: state.url}});
    return false;
  }
}
