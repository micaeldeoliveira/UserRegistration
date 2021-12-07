import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  LoadingController,
  NavController,
  ToastController,
} from '@ionic/angular';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.page.html'
})
export class AddPage implements OnInit {
  public form: FormGroup;

  constructor(
    private navCtrl: NavController,
    public toastCtrl: ToastController,
    private fb: FormBuilder,
    private loadingCtrl: LoadingController,
    private service: UserService
  ) {
    this.form = this.fb.group({
      firstName: [
        '',
        Validators.compose([Validators.minLength(3), Validators.required]),
      ],
      lastName: [
        '',
        Validators.compose([Validators.minLength(2), Validators.required]),
      ],
      email: ['', Validators.compose([Validators.email, Validators.required])],
      birthDate: ['', Validators.compose([Validators.required])],
      schooling: ['', Validators.compose([Validators.required])],
    });
  }

  ngOnInit() {}

  async submit() {
    if (this.form.invalid) return;

    const loading = await this.loadingCtrl.create({
      message: 'Adicionando...',
    });
    loading.present();

    const command = {      
      FirstName: this.form.controls['firstName'].value,
      LastName: this.form.controls['lastName'].value,
      Email: this.form.controls['email'].value,
      BirthDate: this.form.controls['birthDate'].value,
      Schooling: Number.parseInt(this.form.controls['schooling'].value)      
    }

    this.service.add(command).subscribe(
      () => {
        loading.dismiss();
        this.presentToast('Usuário adicionado com sucesso!!!', 'primary');
        this.navCtrl.navigateRoot('users');
      },
      (err) => {
        console.log(err.error);
        loading.dismiss();
        this.presentToast('Erro ao adicionar usuário', 'danger');
      }
    );
  }

  cancel() {
    this.navCtrl.navigateRoot('users');
  }

  async presentToast(msg: string, color: string) {
    const toast = await this.toastCtrl.create({
      message: msg,
      color: color,
      duration: 2000,
    });
    toast.present();
  }
}
