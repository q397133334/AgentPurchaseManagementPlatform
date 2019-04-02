import { Component, Injector, ViewChild, OnInit, AfterViewInit, AfterContentInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import { AppConsts } from '@shared/AppConsts';
import { ConfigurationServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-setting',
  templateUrl: './setting.component.html',
  styleUrls: ['./setting.component.css'],
  animations: [appModuleAnimation()]
})
export class SettingComponent extends AppComponentBase implements OnInit {

  huilv: string;
  chinalogisticsPrice: string;
  saving = false;

  constructor(
    private injector: Injector,
    private _configurationServiceProxy: ConfigurationServiceProxy
  ) {
    super(injector);

  }

  ngOnInit() {
    $.AdminBSB.autoHeight();
    this.huilv = abp.setting.get(AppConsts.settingName.USD_CYN);
    this.chinalogisticsPrice = abp.setting.get(AppConsts.settingName.ChinalogisticsPrice);
    setTimeout(() => {
      $.AdminBSB.input.activate();
    }, 500);
  }

  saveUSD_CYN(): void {
    this.saving = true;
    this._configurationServiceProxy.updateSettingUSD_CYN(parseFloat(this.huilv))
      .subscribe((result) => {
        abp.setting.values[AppConsts.settingName.USD_CYN] = this.huilv;
        this.notify.info(this.l('SavedSuccessfully'));
      });
  }
  saveChinalogisticsPrice(): void {
    this._configurationServiceProxy.updateSettingChinalogisticsPrice(parseFloat(this.chinalogisticsPrice))
      .subscribe((result) => {
        abp.setting.values[AppConsts.settingName.ChinalogisticsPrice] = this.huilv;
        this.notify.info(this.l('SavedSuccessfully'));
      });
  }
}
