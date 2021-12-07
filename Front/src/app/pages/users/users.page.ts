import { Component, OnInit } from '@angular/core';
import { NavController } from '@ionic/angular';
import { UserModel } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.page.html',
})
export class UsersPage implements OnInit {
  public busy: boolean;
  public users: UserModel[];

  constructor(
    private navCtrl: NavController,
    private service: UserService
    ) {}

  ngOnInit() {
    this.busy = true;

    this.service.getAll().subscribe(
      (res: UserModel[]) => {        
        this.users = res;
        this.busy = false;
      },
      (err) => {
        this.busy = false;
        console.log(err.error);
      }
    );
  }

  add() {
    this.navCtrl.navigateRoot(`users/add`);
  }

  details(id: number) {
    this.navCtrl.navigateRoot(`users/details/${id}`);
  }
}
