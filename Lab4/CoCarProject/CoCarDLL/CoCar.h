#include "interfaces.h"
#include "iid.h"

class CoCar : public IEngine, public ICreateCar, public IStats
{
private:
	ULONG m_refCount;
public:
	BSTR	m_petName; // ������������� ����� SysAllocString(), 
	// �������� � ����� ����� SysFreeString()
	int		m_maxSpeed; // ������������ ��������
	int		m_currSpeed; // ������� �������� ����r
	const int MAX_SPEED = 200; //����������� ������������ ��������
	static const int MAX_NAME_LENGTH = 50;
	CoCar();
	virtual ~CoCar();

	// IUnknown
	STDMETHODIMP QueryInterface(REFIID riid, void** pIFace);
	STDMETHODIMP_(DWORD)AddRef();
	STDMETHODIMP_(DWORD)Release();

	// IEngine
	STDMETHODIMP SpeedUp();
	STDMETHODIMP GetMaxSpeed(int* maxSpeed);
	STDMETHODIMP GetCurSpeed(int* curSpeed);

	// IStats
	STDMETHODIMP DisplayStats();
	STDMETHODIMP GetPetName(BSTR* petName);

	// ICreateCar
	STDMETHODIMP SetPetName(BSTR petName);
	STDMETHODIMP SetMaxSpeed(int maxSp);


};

