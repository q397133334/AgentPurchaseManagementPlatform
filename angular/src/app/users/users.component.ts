import { Component, Injector, ViewChild, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { UserServiceProxy, UserDto, PagedResultDtoOfUserDto } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { CreateUserComponent } from 'app/users/create-user/create-user.component';
import { EditUserComponent } from 'app/users/edit-user/edit-user.component';
import { finalize } from 'rxjs/operators';
import { UserBalanceComponent } from './user-balance/user-balance.component';
import { UserBalanceRecordsComponent } from './user-balance-records/user-balance-records.component';

@Component({
    templateUrl: './users.component.html',
    animations: [appModuleAnimation()]
})
export class UsersComponent extends PagedListingComponentBase<UserDto> implements OnInit {

    @ViewChild('createUserModal') createUserModal: CreateUserComponent;
    @ViewChild('editUserModal') editUserModal: EditUserComponent;
    @ViewChild('userBalanceModal') userBalanceModal: UserBalanceComponent;
    @ViewChild('userBalanceRecordsModal') userBalanceRecordsModal: UserBalanceRecordsComponent

    active = false;
    users: UserDto[] = [];

    constructor(
        injector: Injector,
        private _userService: UserServiceProxy
    ) {
        super(injector);
    }
    ngOnInit() {
        super.ngOnInit();
        $.AdminBSB.autoHeight();

    }

    protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
        this._userService.getAll('', '', true, null, null, request.skipCount, request.maxResultCount)
            .pipe(finalize(() => {
                finishedCallback()
            }))
            .subscribe((result: PagedResultDtoOfUserDto) => {
                this.users = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    protected delete(user: UserDto): void {
        abp.message.confirm(
            'Delete user \'' + user.fullName + '\'?',
            (result: boolean) => {
                if (result) {
                    this._userService.delete(user.id)
                        .subscribe(() => {
                            abp.notify.info('Deleted User: ' + user.fullName);
                            this.refresh();
                        });
                }
            }
        );
    }

    // Show Modals
    createUser(): void {
        this.createUserModal.show();
    }

    editUser(user: UserDto): void {
        this.editUserModal.show(user.id);
    }

    balance(user: UserDto): void {
        this.userBalanceModal.show(user.id);
    }
    balanceRecords(user: UserDto): void {
        this.userBalanceRecordsModal.show(user.id);
    }
}
