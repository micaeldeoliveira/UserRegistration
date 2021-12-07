import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AlertController, LoadingController, NavController, ToastController } from '@ionic/angular';
import { UserModel } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.page.html'
})
export class DetailsPage implements OnInit {

  public user: UserModel = null;  
  public busy: boolean = false;
  public form: FormGroup;

  constructor(    
    private route: ActivatedRoute,
    private navCtrl: NavController,
    private alertCtrl: AlertController,
    public toastCtrl: ToastController,
    private fb: FormBuilder,
    private loadingCtrl: LoadingController,
    private service: UserService
  ) {
    this.form = this.fb.group({
      firstName: ['', Validators.compose([
        Validators.minLength(3),        
        Validators.required
      ])],
      lastName: ['', Validators.compose([
        Validators.minLength(2),        
        Validators.required
      ])],
      email: ['', Validators.compose([
        Validators.email,        
        Validators.required
      ])],
      birthDate: ['', Validators.compose([              
        Validators.required
      ])],      
      schooling: ['', Validators.compose([              
        Validators.required
      ])]
    });
  }

  ngOnInit() {
    
    const id = Number.parseInt(this.route.snapshot.paramMap.get('id'));

    if (id > 0) {
      this.busy = true;
      this.service.getById(id)
      .subscribe(
        (res: UserModel) => {
          this.user = res
          this.form.controls['firstName'].setValue(this.user.firstName);
          this.form.controls['lastName'].setValue(this.user.lastName);
          this.form.controls['email'].setValue(this.user.email);
          this.form.controls['birthDate'].setValue(this.user.birthDate);
          this.form.controls['schooling'].setValue(this.user.schooling.toString());
          this.busy = false;          
        },
        (err) => {
          console.log(err);
          this.busy = false;
          this.navCtrl.navigateRoot('users');
        }
      );
    }    
  }

  async submit(){

    if (this.form.invalid)
      return;

    const loading = await this.loadingCtrl.create({ message: 'Editando...' });
    loading.present();

    const command = {      
      Id: this.user.id,
      FirstName: this.form.controls['firstName'].value,
      LastName: this.form.controls['lastName'].value,
      Email: this.form.controls['email'].value,
      BirthDate: this.form.controls['birthDate'].value,
      Schooling: Number.parseInt(this.form.controls['schooling'].value)      
    }
    
    this.service.edit(command)
      .subscribe(
        () => {          
          loading.dismiss();
          this.presentToast('Usuário editado com sucesso!!!','primary');
          this.navCtrl.navigateRoot('users');
          
        },
        (err) => {
          console.log(err);
          loading.dismiss();    
          this.presentToast('Erro ao editar usuário','danger');      
        }
      );

  }

  delete() {
    this.presentAlertConfirm();
  }

  cancel(){
    this.navCtrl.navigateRoot('users');
  }

  async presentAlertConfirm() {
    const alert = await this.alertCtrl.create({
      cssClass: 'my-custom-class',
      header: 'Confirmação!',
      message: `<strong>Deseja excluir o usuário ${this.user.firstName} ${this.user.firstName}?</strong>`,
      buttons: [
       {
          text: 'SIM',
          handler: () => {
            this.remove();
          }
        },
        {
          text: 'NÃO'          
        }
      ]
    });

    await alert.present();
  }

  async remove(){
    const loading = await this.loadingCtrl.create({ message: 'Excluindo...' });
    loading.present();
    
    this.service.delete(this.user.id)
      .subscribe(
        () => {          
          loading.dismiss();
          this.presentToast('Usuário excluído com sucesso!!!','primary');
          this.navCtrl.navigateRoot('users');
          
        },
        (err) => {
          console.log(err.error);
          loading.dismiss();    
          this.presentToast('Erro ao excluir usuário','danger');      
        }
      );
  }

  async presentToast(msg: string, color:string) {
    const toast = await this.toastCtrl.create({
      message: msg,
      color: color,
      duration: 2000
    });
    toast.present();
  }

}
