import { Component, OnInit, ViewChild, ElementRef, Output, EventEmitter, Injector } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { EditOrderDto, UserDto, OrderServiceProxy, UserServiceProxy } from '@shared/service-proxies/service-proxies'
import { AppComponentBase } from '@shared/app-component-base';
import { forkJoin } from 'rxjs';
import { finalize } from 'rxjs/operators';
import * as moment from 'moment';

@Component({
  selector: 'edit-order-modal',
  templateUrl: './edit-order.component.html',
  styleUrls: ['./edit-order.component.css']
})
export class EditOrderComponent extends AppComponentBase implements OnInit {

  @ViewChild('editOrderModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  public order: EditOrderDto;
  public active = false;
  public users: UserDto[];
  public saving = false;
  public arrivalDateTime;

  constructor(
    injector: Injector,
    private _orderServiceProxy: OrderServiceProxy,
    private _userServiceProxy: UserServiceProxy
  ) {
    super(injector)
  }

  ngOnInit() {
  }
  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    const _this = this;
    $(this.modalContent.nativeElement).find('.datetimepicker').datetimepicker({
      format: 'yyyy-mm-dd',
      language: 'zh-CN',
      autoclose: true,
      minView: 2
    }).on('changeDate', function (ev) {
      _this.order.arrivalDateTime = moment(ev.date);
      _this.arrivalDateTime = ev.currentTarget.value;
      ev.currentTarget.focus();
      ev.currentTarget.blur();
    });
  }

  save(): void {
    this.saving = true;
    if (this.order.trueBuyPrice == null) { this.order.trueBuyPrice = 0; }

    // this.order.arrivalDateTime = moment(this.arrivalDateTime);
    this._orderServiceProxy.editOrder(this.order)
      .pipe(finalize(() => { this.saving = false; }))
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
        this.modalSave.emit(null);
      });
  }

  show(id: number): void {
    forkJoin(this._orderServiceProxy.getEditOrder(id), this._userServiceProxy.getAll('', '', true, null, null, 0, 1000))
      .subscribe((results) => {
        this.order = results[0];
        this.users = results[1].items;
        this.arrivalDateTime = this.order.arrivalDateTime.format('YYYY-MM-DD');
        if (this.arrivalDateTime.indexOf('0001') > -1) {
          this.arrivalDateTime = '';
          this.order.arrivalDateTime = null;
        }
        console.log(this.users);
        this.active = true;
        this.modal.show();
      });
  }
  close(): void {
    this.active = false;
    this.modal.hide();
  }

}
