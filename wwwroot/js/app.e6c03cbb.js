(function(e){function t(t){for(var r,o,s=t[0],i=t[1],u=t[2],d=0,b=[];d<s.length;d++)o=s[d],Object.prototype.hasOwnProperty.call(a,o)&&a[o]&&b.push(a[o][0]),a[o]=0;for(r in i)Object.prototype.hasOwnProperty.call(i,r)&&(e[r]=i[r]);l&&l(t);while(b.length)b.shift()();return c.push.apply(c,u||[]),n()}function n(){for(var e,t=0;t<c.length;t++){for(var n=c[t],r=!0,s=1;s<n.length;s++){var i=n[s];0!==a[i]&&(r=!1)}r&&(c.splice(t--,1),e=o(o.s=n[0]))}return e}var r={},a={app:0},c=[];function o(t){if(r[t])return r[t].exports;var n=r[t]={i:t,l:!1,exports:{}};return e[t].call(n.exports,n,n.exports,o),n.l=!0,n.exports}o.m=e,o.c=r,o.d=function(e,t,n){o.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:n})},o.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},o.t=function(e,t){if(1&t&&(e=o(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var n=Object.create(null);if(o.r(n),Object.defineProperty(n,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var r in e)o.d(n,r,function(t){return e[t]}.bind(null,r));return n},o.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return o.d(t,"a",t),t},o.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},o.p="/";var s=window["webpackJsonp"]=window["webpackJsonp"]||[],i=s.push.bind(s);s.push=t,s=s.slice();for(var u=0;u<s.length;u++)t(s[u]);var l=i;c.push([0,"chunk-vendors"]),n()})({0:function(e,t,n){e.exports=n("56d7")},"03c0":function(e,t,n){},"0e1d":function(e,t,n){"use strict";n("c45e")},"101b":function(e,t,n){"use strict";n("8daa")},"1a8b":function(e,t,n){},"271a":function(e,t,n){"use strict";n("1a8b")},"278f":function(e,t,n){"use strict";n("8804")},"355d":function(e,t,n){"use strict";n("03c0")},"40f6":function(e,t,n){"use strict";n("7c75")},"56d7":function(e,t,n){"use strict";n.r(t);n("e260"),n("e6cf"),n("cca6"),n("a79d");var r=n("7a23"),a={class:"form-signin"};function c(e,t,n,c,o,s){var i=Object(r["x"])("Nav"),u=Object(r["x"])("router-view");return Object(r["q"])(),Object(r["d"])(r["a"],null,[Object(r["g"])(i),Object(r["g"])("main",a,[Object(r["g"])(u)])],64)}var o={class:"navbar navbar-expand-md navbar-dark bg-dark mb-4"},s={class:"container-fluid"},i=Object(r["f"])("CHIRP"),u={key:0,class:"navbar-nav me-auto mb-2 mb-md-0"},l={class:"nav-item"},d=Object(r["f"])("Login"),b={class:"nav-item"},p=Object(r["f"])("Register"),f={key:1,class:"navbar-nav me-auto mb-2 mb-md-0"},O={class:"nav-item"};function j(e,t,n,a,c,j){var h=Object(r["x"])("router-link");return Object(r["q"])(),Object(r["d"])("nav",o,[Object(r["g"])("div",s,[Object(r["g"])(h,{to:"/",class:"navbar-brand"},{default:Object(r["F"])((function(){return[i]})),_:1}),Object(r["g"])("div",null,[a.auth?Object(r["e"])("",!0):(Object(r["q"])(),Object(r["d"])("ul",u,[Object(r["g"])("li",l,[Object(r["g"])(h,{to:"/login",class:"nav-link"},{default:Object(r["F"])((function(){return[d]})),_:1})]),Object(r["g"])("li",b,[Object(r["g"])(h,{to:"/register",class:"nav-link"},{default:Object(r["F"])((function(){return[p]})),_:1})])])),a.auth?(Object(r["q"])(),Object(r["d"])("ul",f,[Object(r["g"])("li",O,[Object(r["g"])("a",{href:"#",class:"nav-link",onClick:t[1]||(t[1]=function(){return a.logout&&a.logout.apply(a,arguments)})},"Logout")])])):Object(r["e"])("",!0)])])])}var h=n("1da1"),m=(n("96cf"),n("d3b7"),n("5502")),g=n("6c02"),v={name:"Nav",setup:function(){var e=Object(m["b"])(),t=Object(r["b"])((function(){return e.state.Auth.authenticated})),n=Object(g["c"])(),a=function(){var t=Object(h["a"])(regeneratorRuntime.mark((function t(){return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.next=2,fetch("http://localhost:8000/api/logout",{method:"POST",headers:{"Content-Type":"application/json"},credentials:"include"});case 2:return t.next=4,n.push("/login");case 4:return t.next=6,e.dispatch("Auth/setAuth",!1);case 6:case"end":return t.stop()}}),t)})));return function(){return t.apply(this,arguments)}}();return{auth:t,logout:a}}};v.render=j;var w=v,y={components:{Nav:w}};n("40f6");y.render=c;var x=y,C={id:"main-message"},S={id:"chirp-panel"};function _(e,t,n,a,c,o){var s=Object(r["x"])("ChirpComponent"),i=Object(r["x"])("UsersComponent"),u=Object(r["x"])("Chirps");return Object(r["q"])(),Object(r["d"])(r["a"],null,[Object(r["g"])("div",C,Object(r["z"])(a.message),1),Object(r["g"])("div",S,[Object(r["g"])(s,{id:"send-bar"}),Object(r["g"])(i,{id:"users-comp"}),Object(r["g"])(u,{id:"chirps-comp"})])],64)}n("b0c0");var k=Object(r["I"])("data-v-5e80853b");Object(r["t"])("data-v-5e80853b");var P={id:"chirps-panel"},U=Object(r["g"])("div",{id:"chirps-title"}," Chirps ",-1),T={id:"cb-type"},q=Object(r["g"])("label",{for:"feed-type"},"Followers",-1);Object(r["r"])();var N=k((function(e,t,n,a,c,o){var s=Object(r["x"])("ChirpItem");return Object(r["q"])(),Object(r["d"])("div",P,[U,Object(r["g"])("form",null,[Object(r["G"])(Object(r["g"])("input",{class:"form-control",id:"chirps-ctrl",placeholder:"Start typing",autocomplete:"off","onUpdate:modelValue":t[1]||(t[1]=function(e){return c.userinput=e})},null,512),[[r["C"],c.userinput]]),Object(r["g"])("div",T,[Object(r["G"])(Object(r["g"])("input",{type:"checkbox",id:"feed-type",name:"feed-type","onUpdate:modelValue":t[2]||(t[2]=function(e){return c.followersMode=e})},null,512),[[r["B"],c.followersMode]]),q])]),Object(r["g"])("div",null,[(Object(r["q"])(!0),Object(r["d"])(r["a"],null,Object(r["w"])(c.chirps,(function(e){return Object(r["G"])((Object(r["q"])(),Object(r["d"])(s,{key:e.id,chirp:e},null,8,["chirp"])),[[r["D"],!c.followersMode]])})),128)),(Object(r["q"])(!0),Object(r["d"])(r["a"],null,Object(r["w"])(c.followedChirps,(function(e){return Object(r["G"])((Object(r["q"])(),Object(r["d"])(s,{key:e.id,chirp:e},null,8,["chirp"])),[[r["D"],c.followersMode]])})),128))])])})),I=n("b047"),F=n.n(I),R=(n("fb6a"),n("25f0"),Object(r["I"])("data-v-4b2956f9"));Object(r["t"])("data-v-4b2956f9");var M={class:"chirp-item"},A={class:"chirp-item-user"},G={class:"twoot-item__datetime"},H={class:"twoot-item__content"};Object(r["r"])();var J=R((function(e,t,n,a,c,o){return Object(r["q"])(),Object(r["d"])("div",M,[Object(r["g"])("div",A,Object(r["z"])(n.chirp.username),1),Object(r["g"])("div",G,Object(r["z"])(new Date(n.chirp.dateCreated).toString().slice(0,25)),1),Object(r["g"])("div",H,Object(r["z"])(n.chirp.message),1)])})),V={name:"ChirpItem",props:{chirp:{type:Object,required:!0},datecreated:{type:String,required:!1}}};n("801c");V.render=J,V.__scopeId="data-v-4b2956f9";var z=V,E={name:"Chirps",components:{ChirpItem:z},data:function(){return{chirps:[],followedChirps:[],followersMode:!1,userinput:"",regularFeed:void 0,followedFeed:void 0}},mounted:function(){var e=this,t=Object(r["i"])(),n=t.appContext.config.globalProperties.emitter;n.on("new-chirp",(function(t){t.id=e.chirps.reduce((function(e,t){return Math.max(e,t)}))+1,e.chirps.unshift(t)})),this.regularFeed=new WebSocket("ws://localhost:8000/api/wsfullfeed"),this.followedFeed=new WebSocket("ws://localhost:8000/api/wsfollowedfeed"),this.regularFeed.onopen=function(){e.regularFeed.send("")},this.followedFeed.onopen=function(){e.followedFeed.send("")},this.regularFeed.onmessage=function(t){e.chirps=[];for(var n=JSON.parse(t.data),r=0;r<n.length;r++)e.chirps.push(n[r])},this.followedFeed.onmessage=function(t){e.followedChirps=[];for(var n=JSON.parse(t.data),r=0;r<n.length;r++)e.followedChirps.push(n[r])}},unmounted:function(){this.regularFeed.close(),this.followedFeed.close()},watch:{userinput:F()((function(e){this.regularFeed.send(e),this.followedFeed.send(e)}),20),followersMode:function(e){this.followersMode=e}}};n("271a");E.render=N,E.__scopeId="data-v-5e80853b";var D=E,L=Object(r["I"])("data-v-b94a0f48");Object(r["t"])("data-v-b94a0f48");var W={class:"user-profile"},B={for:"newchirp"},Y=Object(r["g"])("strong",null,"New Chirp",-1);Object(r["r"])();var K=L((function(e,t,n,a,c,o){return Object(r["q"])(),Object(r["d"])("div",W,[Object(r["g"])("form",{class:["send-chirp-panel",{"--exceeded":a.newChirpCharacterCount>140}],onSubmit:t[2]||(t[2]=Object(r["H"])((function(){return a.submit&&a.submit.apply(a,arguments)}),["prevent"]))},[Object(r["g"])("label",B,[Y,Object(r["f"])(" ("+Object(r["z"])(a.newChirpCharacterCount)+"/140)",1)]),Object(r["G"])(Object(r["g"])("textarea",{id:"newchirp",class:"new_chirp",rows:"4","onUpdate:modelValue":t[1]||(t[1]=function(e){return a.data.messageText=e})},null,512),[[r["C"],a.data.messageText]]),Object(r["g"])("button",{class:["w-100 btn btn-lg btn-primary",{"--disabled":a.newChirpCharacterCount>140}],type:"submit"},"Chirp!",2)],34)])})),Q={name:"ChirpSend",setup:function(){var e=Object(r["i"])(),t=e.appContext.config.globalProperties.emitter;console.log("1",t);var n=Object(r["u"])({messageText:""}),a=Object(m["b"])(),c=Object(r["b"])((function(){return n.messageText.length})),o=function(){var e=Object(h["a"])(regeneratorRuntime.mark((function e(){var r,c,o;return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,fetch("http://localhost:8000/api/message",{method:"POST",headers:{"Content-Type":"application/json"},credentials:"include",body:JSON.stringify(n)});case 2:return r=e.sent,e.next=5,r.json();case 5:if(c=e.sent,401==c.status){e.next=11;break}return o={username:a.state.User.name,message:n.messageText,dateCreated:(new Date).toISOString()},e.next=10,t.emit("new-chirp",o);case 10:n.messageText="";case 11:case"end":return e.stop()}}),e)})));return function(){return e.apply(this,arguments)}}();return{data:n,submit:o,newChirpCharacterCount:c}}};n("7f8c");Q.render=K,Q.__scopeId="data-v-b94a0f48";var X=Q,Z=Object(r["I"])("data-v-a0cf4d28");Object(r["t"])("data-v-a0cf4d28");var $={id:"users-panel"},ee=Object(r["g"])("div",{id:"users-title"}," Users ",-1),te={class:"table table-striped table-bordered"};Object(r["r"])();var ne=Z((function(e,t,n,a,c,o){var s=Object(r["x"])("UserItem");return Object(r["q"])(),Object(r["d"])("div",$,[ee,Object(r["g"])("table",te,[Object(r["g"])("tbody",null,[Object(r["g"])("tr",null,[(Object(r["q"])(!0),Object(r["d"])(r["a"],null,Object(r["w"])(c.users,(function(e){return Object(r["q"])(),Object(r["d"])(s,{key:e.id,userProp:e},null,8,["userProp"])})),128))])])])])})),re=(n("6062"),n("3ca3"),n("ddb0"),n("d81d"),Object(r["I"])("data-v-d4826976"));Object(r["t"])("data-v-d4826976");var ae=Object(r["f"])(" Unfollow "),ce=Object(r["f"])(" Follow ");Object(r["r"])();var oe=re((function(e,t,n,a,c,o){return Object(r["q"])(),Object(r["d"])("div",null,[Object(r["g"])("td",null,Object(r["z"])(c.user.name),1),Object(r["g"])("td",null,[Object(r["g"])("button",{type:"button",class:"btn-followed",onClick:t[1]||(t[1]=function(){return o.follow&&o.follow.apply(o,arguments)})},[c.user.followed?(Object(r["q"])(),Object(r["d"])(r["a"],{key:0},[ae],64)):(Object(r["q"])(),Object(r["d"])(r["a"],{key:1},[ce],64))])])])})),se={name:"UserItem",props:["userProp"],data:function(){return{user:{}}},mounted:function(){this.user=this.userProp},methods:{follow:function(){var e=Object(h["a"])(regeneratorRuntime.mark((function e(){var t;return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return t=this.user.followed?"http://localhost:8000/api/unfollow":"http://localhost:8000/api/follow",e.next=3,fetch(t,{method:"POST",headers:{"Content-Type":"application/json"},credentials:"include",body:JSON.stringify({FollowedName:this.user.name})});case 3:this.user.followed=!this.user.followed;case 4:case"end":return e.stop()}}),e,this)})));function t(){return e.apply(this,arguments)}return t}()}};n("355d");se.render=oe,se.__scopeId="data-v-d4826976";var ie=se,ue={name:"Users",components:{UserItem:ie},data:function(){return{users:[]}},mounted:function(){var e=this;return Object(h["a"])(regeneratorRuntime.mark((function t(){var n,r,a,c,o;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.next=2,fetch("http://localhost:8000/api/followed",{headers:{"Content-Type":"application/json"},credentials:"include"});case 2:return n=t.sent,t.next=5,n.json();case 5:return r=t.sent,a=new Set(r.map((function(e){var t=e.followed;return[t].toString()}))),t.next=9,fetch("http://localhost:8000/api/users",{headers:{"Content-Type":"application/json"},credentials:"include"});case 9:return n=t.sent,t.next=12,n.json();case 12:for(e.users=t.sent,c=0;c<e.users.length;c++)o=e.users[c],a.has(o.name)?o.followed=!0:o.followed=!1;case 14:case"end":return t.stop()}}),t)})))()},methods:{follow:function(e){console.log(e)}}};n("278f");ue.render=ne,ue.__scopeId="data-v-a0cf4d28";var le=ue,de={name:"Home",components:{ChirpComponent:X,UsersComponent:le,Chirps:D},setup:function(){var e=Object(r["v"])("You are not logged in!"),t=Object(m["b"])(),n=Object(g["c"])();return Object(r["o"])(Object(h["a"])(regeneratorRuntime.mark((function r(){var a,c;return regeneratorRuntime.wrap((function(r){while(1)switch(r.prev=r.next){case 0:return r.next=2,fetch("http://localhost:8000/api/user",{headers:{"Content-Type":"application/json"},credentials:"include"});case 2:return a=r.sent,r.next=5,a.json();case 5:if(c=r.sent,401!=c.status){r.next=13;break}return r.next=9,t.dispatch("Auth/setAuth",!1);case 9:return r.next=11,n.push("/login");case 11:r.next=18;break;case 13:return e.value="Hi, ".concat(c.name,"!"),r.next=16,t.dispatch("Auth/setAuth",!0);case 16:return r.next=18,t.dispatch("User/setName",c.name);case 18:case"end":return r.stop()}}),r)})))),{message:e}}};n("0e1d");de.render=_;var be=de,pe=Object(r["I"])("data-v-3ef39428");Object(r["t"])("data-v-3ef39428");var fe=Object(r["g"])("h1",{class:"h3 mb-3 fw-normal"},"Please sign in",-1),Oe=Object(r["g"])("button",{class:"w-100 btn btn-lg btn-primary",type:"submit"},"Sign in",-1);Object(r["r"])();var je=pe((function(e,t,n,a,c,o){return Object(r["q"])(),Object(r["d"])("form",{onSubmit:t[3]||(t[3]=Object(r["H"])((function(){return a.submit&&a.submit.apply(a,arguments)}),["prevent"])),id:"login-form"},[fe,Object(r["G"])(Object(r["g"])("input",{"onUpdate:modelValue":t[1]||(t[1]=function(e){return a.data.UserName=e}),class:"form-control",placeholder:"User Name",required:""},null,512),[[r["C"],a.data.UserName]]),Object(r["G"])(Object(r["g"])("input",{"onUpdate:modelValue":t[2]||(t[2]=function(e){return a.data.Password=e}),type:"password",class:"form-control",placeholder:"Password",required:""},null,512),[[r["C"],a.data.Password]]),Oe],32)})),he={name:"Login",setup:function(){var e=Object(r["u"])({UserName:"",Password:""}),t=Object(g["c"])(),n=function(){var n=Object(h["a"])(regeneratorRuntime.mark((function n(){return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return n.next=2,fetch("http://localhost:8000/api/login",{method:"POST",headers:{"Content-Type":"application/json"},credentials:"include",body:JSON.stringify(e)});case 2:return n.next=4,t.push("/");case 4:case"end":return n.stop()}}),n)})));return function(){return n.apply(this,arguments)}}();return{data:e,submit:n}}};n("7ef9");he.render=je,he.__scopeId="data-v-3ef39428";var me=he,ge=Object(r["I"])("data-v-eb2b88fc");Object(r["t"])("data-v-eb2b88fc");var ve=Object(r["g"])("h1",{class:"h3 mb-3 fw-normal"},"Please register",-1),we=Object(r["g"])("button",{class:"w-100 btn btn-lg btn-primary",type:"submit"},"Submit",-1);Object(r["r"])();var ye=ge((function(e,t,n,a,c,o){return Object(r["q"])(),Object(r["d"])("form",{onSubmit:t[3]||(t[3]=Object(r["H"])((function(){return a.submit&&a.submit.apply(a,arguments)}),["prevent"])),id:"register-form"},[ve,Object(r["G"])(Object(r["g"])("input",{"onUpdate:modelValue":t[1]||(t[1]=function(e){return a.data.UserName=e}),class:"form-control",placeholder:"User Name",required:""},null,512),[[r["C"],a.data.UserName]]),Object(r["G"])(Object(r["g"])("input",{"onUpdate:modelValue":t[2]||(t[2]=function(e){return a.data.password=e}),type:"password",class:"form-control",placeholder:"Password",required:""},null,512),[[r["C"],a.data.password]]),we],32)})),xe={name:"Register",setup:function(){var e=Object(r["u"])({UserName:"",Password:""}),t=Object(g["c"])(),n=function(){var n=Object(h["a"])(regeneratorRuntime.mark((function n(){return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return n.next=2,fetch("http://localhost:8000/api/register",{method:"POST",headers:{"Content-Type":"application/json"},body:JSON.stringify(e)});case 2:return n.next=4,t.push("/login");case 4:case"end":return n.stop()}}),n)})));return function(){return n.apply(this,arguments)}}();return{data:e,submit:n}}};n("101b");xe.render=ye,xe.__scopeId="data-v-eb2b88fc";var Ce=xe,Se=[{path:"/",component:be},{path:"/login",component:me},{path:"/register",component:Ce}],_e=Object(g["a"])({history:Object(g["b"])(),routes:Se}),ke=_e,Pe={namespaced:!0,state:{authenticated:!1},mutations:{SET_AUTH:function(e,t){e.authenticated=t}},actions:{setAuth:function(e,t){var n=e.commit;n("SET_AUTH",t)}},modules:{}},Ue={namespaced:!0,state:{name:""},mutations:{SET_NAME:function(e,t){e.name=t}},actions:{setName:function(e,t){var n=e.commit;n("SET_NAME",t)}},modules:{}},Te=Object(m["a"])({state:{},mutations:{},actions:{},modules:{Auth:Pe,User:Ue}}),qe=n("14b7"),Ne=Object(qe["a"])(),Ie=Object(r["c"])(x).use(Te).use(ke);Ie.config.globalProperties.emitter=Ne,Ie.mount("#app")},"5a02":function(e,t,n){},"7c75":function(e,t,n){},"7ef9":function(e,t,n){"use strict";n("a16e")},"7f8c":function(e,t,n){"use strict";n("5a02")},"801c":function(e,t,n){"use strict";n("9dea")},8804:function(e,t,n){},"8daa":function(e,t,n){},"9dea":function(e,t,n){},a16e:function(e,t,n){},c45e:function(e,t,n){}});
//# sourceMappingURL=app.e6c03cbb.js.map